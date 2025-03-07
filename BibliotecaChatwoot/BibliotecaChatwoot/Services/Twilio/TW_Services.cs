using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Types;

namespace BibliotecaChatwoot.Services.Twilio
{
    public class TW_Services
    {
        Config config;
        public TW_Services()
        {
            config = new Config();
        }
        public async Task SendTemplateAsync(string To,string template_ssid, Dictionary<string, object> contentVariables)
        {
            TwilioClient.Init(config.accountSid, config.authToken);
            var contentJson = JsonConvert.SerializeObject(contentVariables, Formatting.Indented);

            var message = await MessageResource.CreateAsync(
                contentSid: template_ssid,
                to: new PhoneNumber($"whatsapp:{To}"),
                from: new PhoneNumber(config.from),
                contentVariables: contentJson
                );

            Console.WriteLine(message.Body);
        }
    }
}
