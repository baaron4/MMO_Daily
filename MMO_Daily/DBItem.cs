using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Daily
{
    public class DBItem
    {
        public string name;
        public List<DateTime> CompletionTimes;

        public DBItem(string name, List<DateTime> compTimes)
        {
            this.name = name;
            this.CompletionTimes = compTimes;
        }

    }
}
