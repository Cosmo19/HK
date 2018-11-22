using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Room
    {
        public int ID { get; set; }
        
        public int Code { get; set; }

        public List<int> CodeList = new List<int>();

        public string GetRoom
        {
            get
            {
                return String.Format("Room: {0:D2} Code: {1}", ID, Code);
            }
            set
            {
                return;
            }
        }
    }
}
