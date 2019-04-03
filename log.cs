using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HacTrac
{
    class log

    {
        private void DisplayEventAndLogInformation(EventLogReader logreader)

        {

            for (EventRecord eventInstance = logreader.ReadEvent();

                null != eventInstance; eventInstance = logreader.ReadEvent())

            {

                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("Event ID: {0}", eventInstance.Id);

                Console.WriteLine("Publisher:{0}", eventInstance.ProviderName);

                Console.WriteLine("Keywords:{0}", eventInstance.Keywords);



                try

                {

                    Console.WriteLine("Description: {0}", eventInstance.FormatDescription());

                }

                catch (EventLogException ex)

                {

                    Console.WriteLine("Description: {0}", ex.Message);

                }


                              EventLogRecord logRecord = (EventLogRecord)eventInstance;

                Console.WriteLine("Container Event Log: {0}", logRecord.ContainerLog);

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
        public void QueryRemoteComputer()
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
                return;
            }
        }
    }
}
