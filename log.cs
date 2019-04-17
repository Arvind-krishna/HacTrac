using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacTrac
{
    enum mode { security, sysmon };
    
    class log

    {
        public static int viewcount = 50;

        DataSet data = new DataSet();
        private void DisplayEventAndLogInformation(EventLogReader logreader)

        {
            DataSet ds = new DataSet();


                ds.Tables.Add("Events");
            ds.Tables["Events"].Columns.Add("EventID");
            ds.Tables["Events"].Columns.Add("Level");
                

                ds.Tables["Events"].Columns.Add("Time");
                
                ds.Tables["Events"].Columns.Add("Task");
                ds.Tables["Events"].Columns.Add("User");
                ds.Tables["Events"].Columns.Add("Operation");
                ds.Tables["Events"].Columns.Add("XML");
                


                int i = 0;

            for (EventRecord eventInstance = logreader.ReadEvent();

                null != eventInstance; eventInstance = logreader.ReadEvent())

            {

                ds.Tables["Events"].Rows.Add(eventInstance.Id, eventInstance.LevelDisplayName, eventInstance.TimeCreated, eventInstance.TaskDisplayName, eventInstance.UserId, eventInstance.OpcodeDisplayName, eventInstance.ToXml());

                ++i;
                if (i > viewcount) break;
            }


            
                data = ds;
        
               

              

        }

      

        public void FilterLog(DataGridView ds)
        {

            foreach (DataGridViewRow row in ds.Rows)
            {
                string xmlst = row.Cells["XML"].Value.ToString(); ;
                //MessageBox.Show(xmlst);
                try
                {
                    if ((xmlst.Contains("explorer.exe") || xmlst.Contains("VBoxTray.exe")) && xmlst.Contains("<EventID>11</EventID>") && (xmlst.Contains("C:\\Users\\test\\AppData\\Local\\Temp\\1\\VirtualBox Dropped Files") || xmlst.Contains("C:\\Users\\test\\Desktop") || xmlst.Contains("C:\\Users\\Administrator\\Desktop")))
                    {

                        DataRow drow = ((DataRowView)row.DataBoundItem).Row;


                        Alerts.alerts.ImportRow(drow);
                        //Alerts.alerts.Rows[Alerts.alerts.Rows.Count - 1].DefaultCellStyle.BackColor = Color.OrangeRed;
                    }

                    else if (xmlst.Contains("<Data Name='LogonType'>3</Data>"))
                    {
                        DataRow drow = ((DataRowView)row.DataBoundItem).Row;


                        Alerts.alerts.ImportRow(drow);
                    }

                    else if (xmlst.Contains("<EventID>4656</EventID>") && xmlst.Contains("C:\\Confidential\\"))
                        {

                        DataRow drow = ((DataRowView)row.DataBoundItem).Row;


                        Alerts.alerts.ImportRow(drow);
                    }

                    else if (xmlst.Contains("<EventID>4663</EventID>") && xmlst.Contains("C:\\Confidential\\"))
                        {

                        DataRow drow = ((DataRowView)row.DataBoundItem).Row;


                        Alerts.alerts.ImportRow(drow);
                       }

                    else if (xmlst.Contains("<EventID>4690</EventID>"))
                    {

                        DataRow drow = ((DataRowView)row.DataBoundItem).Row;


                        Alerts.alerts.ImportRow(drow);
                    }




                }
                catch (Exception bee) { MessageBox.Show(bee.Message); }
            }
                
        }


        public void ClearLog(string logname, Queryobj o, bool backup,string fname="")
        {
            EventLogSession session = new EventLogSession(
               o.IP,                               
               o.domain,                                  
               o.username,                                
               o.password,
               SessionAuthentication.Default);
            if(backup==true)
            {
                
                session.ExportLog(logname, PathType.LogName, "*",fname);
                
            }

            session.ClearLog(logname);
            


        }

        public DataSet fullquery(Queryobj o)

        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            log l = new log();
            o.logname = "Microsoft-Windows-Sysmon/Operational";
            ds1 = l.QueryRemoteComputer("*[System[(EventID=11) or (EventID=1) or (EventID=3)]]", o,mode.sysmon);
            o.logname = "Security";
            ds2 = l.QueryRemoteComputer("*[System[(EventID=4656) or (EventID=4663) or (EventID=4690) or (EventID=4634) or (EventID=4624)]]", o,mode.security);
            ds1.Merge(ds2);
            return ds1;

        }

        internal DataSet QueryRemoteComputer(string querystring, Queryobj o, mode a)
        {

            string queryString = querystring; // XPATH Query
            

            EventLogSession session = new EventLogSession(
                o.IP,                               
                o.domain,                                  
                o.username,                                
                o.password,
                SessionAuthentication.Default);

            

            // Query the Application log on the remote computer.
            EventLogQuery query = new EventLogQuery(o.logname, PathType.LogName, queryString);
            query.Session = session;

            try
            {
                EventLogReader logReader = new EventLogReader(query);

                // Display event info
                DisplayEventAndLogInformation(logReader);

            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);

            }
            return data;
        }
    }
}
        
