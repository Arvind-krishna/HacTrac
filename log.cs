using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HacTrac
{
    enum mode { security, sysmon };
    class log

    {

        DataSet data = new DataSet();
        private void DisplayEventAndLogInformation(EventLogReader logreader, mode m)

        {
            DataSet ds = new DataSet();

            if (m == mode.sysmon)
            {

                ds.Tables.Add("Events");
                ds.Tables["Events"].Columns.Add("Level");
                ds.Tables["Events"].Columns.Add("Time");
                ds.Tables["Events"].Columns.Add("Event ID");
                ds.Tables["Events"].Columns.Add("Task");
                ds.Tables["Events"].Columns.Add("User");
                ds.Tables["Events"].Columns.Add("Operation");
                ds.Tables["Events"].Columns.Add("XML");


                int i = 0;

                for (EventRecord eventInstance = logreader.ReadEvent();

                    null != eventInstance; eventInstance = logreader.ReadEvent())

                {

                    ds.Tables["Events"].Rows.Add(eventInstance.LevelDisplayName, eventInstance.TimeCreated, eventInstance.Id, eventInstance.TaskDisplayName, eventInstance.UserId, eventInstance.OpcodeDisplayName, eventInstance.ToXml());

                    ++i;
                    if (i > 10) break;




                }

                data = ds;

            }
            else
            {

                ds.Tables.Add("Events");
                ds.Tables["Events"].Columns.Add("Level");
                ds.Tables["Events"].Columns.Add("Time");
                ds.Tables["Events"].Columns.Add("Event ID");
                ds.Tables["Events"].Columns.Add("Task");
                ds.Tables["Events"].Columns.Add("Source");
                ds.Tables["Events"].Columns.Add("XML");




                int i = 0;
                for (EventRecord eventInstance = logreader.ReadEvent();

                    null != eventInstance; eventInstance = logreader.ReadEvent())

                {

                    ds.Tables["Events"].Rows.Add(eventInstance.LevelDisplayName, eventInstance.TimeCreated, eventInstance.Id, eventInstance.TaskDisplayName, eventInstance.ProviderName,eventInstance.ToXml());

                    ++i;
                    if (i > 10) break;


                }

                data = ds;

            }

        }

        public static SecureString GetPassword(string inputString)

        {

            SecureString secureString = new SecureString();



            foreach (Char character in inputString)

            {

                secureString.AppendChar(character);

            }

            return secureString;

        }


        internal DataSet QueryRemoteComputer(string querystring, Queryobj o, mode a)
        {

            string queryString = querystring; // XPATH Query
            SecureString pw = GetPassword(o.password);

            EventLogSession session = new EventLogSession(
                o.IP,                               // Remote Computer
                o.domain,                                  // Domain
                o.username,                                // Username
                pw,
                SessionAuthentication.Default);

            pw.Dispose();

            // Query the Application log on the remote computer.
            EventLogQuery query = new EventLogQuery(o.logname, PathType.LogName, queryString);
            query.Session = session;

            try
            {
                EventLogReader logReader = new EventLogReader(query);

                // Display event info
                DisplayEventAndLogInformation(logReader, a);

            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);

            }
            return data;
        }
    }
}
        
