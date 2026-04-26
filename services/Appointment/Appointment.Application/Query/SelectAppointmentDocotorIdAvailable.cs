using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Query
{
    public  class SelectAppointmentDocotorIdAvailable:IRequest<List<(DateTime start, DateTime end)>>
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }  
        public SelectAppointmentDocotorIdAvailable( int Id, DateTime? dateTime) {
            this.Id = Id;
            this.Date = dateTime;

                
                
         }
    }
}
