using doctor.application.Command;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace doctor.application.handler.CommandHandler 
{
    public class SendMessageHandler : IRequestHandler<SendMessage, bool>
    {
        private readonly IConfiguration _configuration;

        public SendMessageHandler(IConfiguration confi)
        {
            _configuration= confi;
        
        }
        
        public  async Task<bool> Handle(SendMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var sid = _configuration["Twilio:AccountSid"];
                var token = _configuration["Twilio:AuthToken"];
                var from = _configuration["Twilio:FromNumber"];
                var message = $"  {request.notifation.NameDocotor} ي دكتور  موعد جديد\n" +
                         $"المريض: {request.notifation.Namepatient}\n" +
                         $"الوقت: {request.notifation.StartTime}\n" +
                         $"الموعد: {request.notifation.Notes}";
                var phone = request.notifation.Phone;

                if (phone.StartsWith("0"))
                    phone = "+2" + phone;
         

                TwilioClient.Init(sid, token);
                var result = await MessageResource.CreateAsync(
                 body: message,
                from: new PhoneNumber(from),
                to: new PhoneNumber(phone));
                Console.WriteLine($"SID: {result.Sid}");
                Console.WriteLine($"Status: {result.Status}");
                Console.WriteLine($"Error: {result.ErrorMessage}");
                if (result.Sid != null)
                {
                    return true;


                }

                else return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("🔥 TWILIO FULL ERROR:");
                Console.WriteLine(ex.ToString()); // مهم جدًا

                throw;

            }

        }
    }
}
