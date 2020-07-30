using AfricasTalkingCS;
using Reaiot.Web.Constants;

namespace ReaiotBackend.Services
{
    public class MessageService
    {
        // for things like user authentication using twilio sms client or AfricasTalking 
        
        AfricasTalkingGateway gateway;
        public MessageService()
        {
            gateway = new AfricasTalkingGateway(AfricasTalkingConstants.Username,
                                                AfricasTalkingConstants.Apikey,
                                                AfricasTalkingConstants.Env);
        }
        
        public void SendMessage(string  recepient, string message)
        {
           
            var messageDemo = "Hello Africa, Jambo Kenya. Mko sawa Lakini?";
           string recepientDemo = "+2540742267032";
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
