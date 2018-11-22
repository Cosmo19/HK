using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Guest
    {
        public string PrimaryName { get; set; }

        public string SecondaryName { get; set; }

        public Room Room { get; set; }

        public String GetName
        {
            get
            {
                return String.Format("{0} {1}", SecondaryName, PrimaryName).ToUpper();
            }
            set
            {
                return;
            }
        }
    }
}
