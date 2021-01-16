using AfricasTalkingCS;
using Reaiot.Web.Constants;
using System;

namespace ReaiotBackend.Services
{
    public class MessageService
    {
        
        static AfricasTalkingGateway gateway = new AfricasTalkingGateway(AfricasTalkingConstants.Username, 
                                                    AfricasTalkingConstants.Apikey,  AfricasTalkingConstants.Env);
      
        public static void SendMessage(string  recepient, string message)
        {
           
            var messageDemo = "Hello Africa, Jambo Kenya. Mko sawa Lakini?";
            string recepientDemo = "+254742267032";
            try
            {
                var sms = gateway.SendMessage(recepientDemo,   messageDemo + message +  DateTime.Now);
                foreach (var res in sms["SMSMessageData"]["Recipients"])
                {
                    var number = res["number"];
                    var status = res["status"];
                    var messageId = res["messageId"];
                    var cost = res["cost"];                   
                }
            }
            catch (AfricasTalkingGatewayException exception)
            {
                throw exception;
            }

        }

    }
}
