using doctor.application.Command;
using EventMassage;
using MassTransit;
using MediatR;

namespace DoctorandDepartmant.api.Consumer
{
    public class ConsumerEvent : IConsumer<EventNotfiation>
    {
        private readonly  IMediator mediator;
        public ConsumerEvent(IMediator mediator)
       
        {
            this.mediator = mediator;
        }

        public async Task Consume(ConsumeContext<EventNotfiation> context)
        {
           var result= context.Message;
            var message = new SendMessage(result);
            await mediator.Send(message);
           
        }
    }
}
