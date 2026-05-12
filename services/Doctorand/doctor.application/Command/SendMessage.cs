using EventMassage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Command
{
    public  class SendMessage:IRequest<bool>
    {
        public EventNotfiation notifation;
        public SendMessage(EventNotfiation notifati)
        {
            this.notifation = notifati;
        }
    }
}
