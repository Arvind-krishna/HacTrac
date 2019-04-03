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
    class log

    {
        DataSet data = new DataSet();
        private void DisplayEventAndLogInformation(EventLogReader logreader)

        {
            DataSet ds = new DataSet();
            ds.Tables.Add("Events");
            ds.Tables["Events"].Columns.Add("ComputerName");
            ds.Tables["Events"].Columns.Add("EventId");
            ds.Tables["Events"].Columns.Add("EventType");
            ds.Tables["Events"].Columns.Add("SourceName");
            
            

            for (EventRecord eventInstance = logreader.ReadEvent();

                null != eventInstance; eventInstance = logreader.ReadEvent())

            {

                ds.Tables["Events"].Rows.Add(eventInstance.ProviderName,eventInstance.Id,eventInstance.ActivityId, eventInstance.Keywords);

               

                
                

            }

            data = ds;

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
        public DataSet QueryRemoteComputer()
        {
            string queryString = "*[System/Level=2]"; // XPATH Query
            SecureString pw = GetPassword("@mmba13!");

            EventLogSession session = new EventLogSession(
                "192.168.56.2",                               // Remote Computer
                "krish.com",                                  // Domain
                "Administrator",                                // Username
                pw,
                SessionAuthentication.Default);

            pw.Dispose();

            // Query the Application log on the remote computer.
            EventLogQuery query = new EventLogQuery("Application", PathType.LogName, queryString);
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
