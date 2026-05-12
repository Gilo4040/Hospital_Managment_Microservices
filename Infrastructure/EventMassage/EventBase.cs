using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventMassage
{
    public  class EventBase
    {
        public string ID {  get; set; }
        public DateTime dateTime { get; set; }
        public EventBase( )
        {
            ID = Guid.NewGuid().ToString();
            dateTime = DateTime.Now;

        }
    }
}
