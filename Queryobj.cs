using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HacTrac
{
    public class Queryobj
    {
        public string username;
        public string password;
        public string IP;
        public string domain = null;
        


        public Queryobj(string UnameBox, string PassBox, string IPbox, string DomBox)
        {
            this.username = UnameBox;
            this.password = PassBox;
            this.IP = IPbox;
            this.domain = DomBox;
        }
        public Queryobj() { }
    }

    

     
      
    
}
