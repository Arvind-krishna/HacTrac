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
    
    class Log

    {
        

        DataSet data = new DataSet();
        private void DisplayEventAndLogInformation(EventLogReader logreader)

        {
            
            DataSet ds = new DataSet();


                ds.Tables.Add("Events");
            ds.Tables["Events"].Columns.Add("EventID");
            ds.Tables["Events"].Columns.Add("Level");
                

                ds.Tables["Events"].Columns.Add("Time");
                
                ds.Tables["Events"].Columns.Add("Task");
                
                ds.Tables["Events"].Columns.Add("Operation");
                ds.Tables["Events"].Columns.Add("XML");
            





            for (EventRecord eventInstance = logreader.ReadEvent();

                null != eventInstance; eventInstance = logreader.ReadEvent())

            {

                ds.Tables["Events"].Rows.Add(eventInstance.Id, eventInstance.LevelDisplayName, eventInstance.TimeCreated, eventInstance.TaskDisplayName, eventInstance.OpcodeDisplayName, eventInstance.ToXml());
               
                
            }


            
                data = ds;
        
               

              

        }

      

        public void FilterLog(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                string xmlst = row["XML"].ToString();
                MessageBox.Show(xmlst);
                  
                //MessageBox.Show(xmlst);
                try
                {
                    if ((xmlst.Contains("C:\\Windows\\Explorer") || xmlst.Contains("VBoxTray.exe")) && xmlst.Contains("<EventID>11</EventID>") && (xmlst.Contains("VirtualBox Dropped Files") || xmlst.Contains("Desktop")))
                    {

                        


                        Alerts.alerts.Rows.Add(row.ItemArray);
                       
                    }

                    else if (xmlst.Contains("<EventID>21</EventID>") || xmlst.Contains("<EventID>23</EventID>") || xmlst.Contains("<EventID>24</EventID>") || xmlst.Contains("<EventID>25</EventID>"))
                    {
                       


                        Alerts.alerts.Rows.Add(row.ItemArray);
                    }

                    /*  else if (xmlst.Contains("<EventID>4656</EventID>") && xmlst.Contains("C:\\Confidential\\"))
                          {

                          DataRow roe = ((DataRowView)row.DataBoundItem).Row;


                          Alerts.alerts.Rows.Add(roe.ItemArray);}*/


                    else if ((xmlst.Contains("<EventID>4663</EventID>") && xmlst.Contains("C:\\Confidential\\") && xmlst.Contains("notepad")))
                        {

                        


                        Alerts.alerts.Rows.Add(row.ItemArray);
                    }

                    else if (xmlst.Contains("<EventID>4690</EventID>")|| xmlst.Contains("<EventID>4660</EventID>"))
                    {

                        


                        Alerts.alerts.Rows.Add(row.ItemArray);
                    }




                }
                catch (Exception bee) {  }
            }
                
        }


        public void ClearLog(string logname, Queryobj o,string fname="")
        {
            EventLogSession session = new EventLogSession(
               o.IP,                               
               o.domain,                                  
               o.username,                                
               o.password,
               SessionAuthentication.Default);
           

            session.ClearLog(logname);
            Alerts.alerts.Clear();
            


        }

        public DataSet fullquery(Queryobj o)

        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            
            Log l = new Log();
             o.logname = "Microsoft-Windows-Sysmon/Operational";
             ds1 = l.QueryRemoteComputer("*[System[(EventID=11)]]", o);
             o.logname = "Security";
             ds2 = l.QueryRemoteComputer("*[System[(EventID=4663) or (EventID=4660) or (EventID=4656) or (EventID=4690)]]", o);
             ds1.Merge(ds2);
             o.logname = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational";
             ds3 = l.QueryRemoteComputer("*[System[(EventID=21) or (EventID=24) or (EventID=23) or (EventID=25)]]", o);
             ds1.Merge(ds3);



            return ds1;

        }

        public DataSet QueryRemoteComputer(string querystring, Queryobj o)
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
        
