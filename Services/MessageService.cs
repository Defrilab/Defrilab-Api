using AfricasTalkingCS;
using Reaiot.Web.Constants;

namespace ReaiotBackend.Services
{
    public class MessageService
    {
        // for things like user authentication using twilio sms client or AfricasTalking 
        
        static AfricasTalkingGateway gateway = new AfricasTalkingGateway(AfricasTalkingConstants.Username,
                                                AfricasTalkingConstants.Apikey,
                                                AfricasTalkingConstants.Env);
        public MessageService()
        {
           
        }
        
         public static void SendMessage(string  recepient, string message)
        {
           
            var messageDemo = "Hello Africa, Jambo Kenya. Mko sawa Lakini?";
            string recepientDemo = "+254742267032";
            try
            {
                var sms = gateway.SendMessage(recepientDemo,   messageDemo);
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
               
            }

        }

    }
}
