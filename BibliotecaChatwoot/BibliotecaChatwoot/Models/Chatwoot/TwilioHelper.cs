using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class TwilioHelper
    {
        public void SendMessage()
        {
            string accountSid = "ACddad762193f3d107774e90d9020be10b";
            string authToken = "6a4a464feeeca75458110751919aa389";

            // Inicializa el cliente Twilio con tus credenciales
            TwilioClient.Init(accountSid, authToken);


            string twilioPhoneNumber = "whatsapp:+5213359800794";
            string recipientPhoneNumber = "whatsapp:+523331830952";
            string messageBody = "Ey, Pablo Alvarez! 🏍️ Casi te ganas tu moto, ¡qué emoción! 😁 Ahora manda tu video respondiendo estas preguntillas:\r\n\r\n1️⃣ ¿Cuál moto te gustaría y para qué la quieres?\r\n2️⃣ ¿Cuánto ganas y en qué trabajas?\r\n3️⃣ ¡Cuéntanos una historia en moto!\r\n\r\n¡Esperamos tu video, campeón! 📹💨";

            try
            {
                // Envía el mensaje con la imagen
                var message = MessageResource.Create(
                    from: new PhoneNumber(twilioPhoneNumber),
                    to: new PhoneNumber(recipientPhoneNumber),
                    body: messageBody
                );

                Console.WriteLine($"Mensaje enviado SID: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el mensaje: {ex.Message}");
            }
        }
    }
}
