using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HacTrac
{
    public class Queryobj
    {
        public string username;
        public SecureString password;
        public string IP;
        public string domain = null;
        public string logname;

        public static SecureString GetPassword(string inputString)

        {

            SecureString secureString = new SecureString();



            foreach (Char character in inputString)

            {

                secureString.AppendChar(character);

            }

            return secureString;

        }

        public Queryobj(string UnameBox, string PassBox, string IPbox, string DomBox)
        {
            this.username = UnameBox;
            this.password = GetPassword(PassBox);
            this.IP = IPbox;
            this.domain = DomBox;
            
        }
        public Queryobj() { }


    }

    

     
      
    
}
