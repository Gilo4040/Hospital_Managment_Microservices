using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMassage
{
    public  class EventNotfiation:EventBase
    {
      
            
        public int Id { get; set; }

        public int IdDocotr { get; set; }
      
        public string NameDocotor { get; set; }
        public string Namepatient { get; set; }


        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public string Phone { get;set; }  
       

        public string? Notes { get; set; }

    }
}
