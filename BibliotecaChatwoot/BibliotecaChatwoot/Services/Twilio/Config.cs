using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Services.Twilio
{
    public class Config
    {
        public string accountSid { get; set; } = "AC394ceefe4187110ddfe10c0af31a9d4b";
        public string authToken { get; set; } = "a5e3b2351d10e775196937acc7a574c6";
        public string from { get; set; } = "whatsapp:+5213359800766";
        public List<WA_Templates> Templates { get; set; }
        public Config()
        {
            Templates = new List<WA_Templates>();
            Templates.Add(new WA_Templates()
            {
                Name = "encuesta_pacientes",
                SSID = "HXa04494e9dc6baa67887e384d0ad24091",
                Body = @"Hola {{1}}, queremos ser siempre mejores para ti. Nos podrias decir como calificarías la atención brindada por tu medico {{2}}?

por favor"
            });


            Templates.Add(new WA_Templates()
            {
                Name = "paciente",
                SSID = "HX7d478e57dcf0aa9a34b7280110781c08",
                Body = @"Hola, buen día. Su siguiente paciente ya llego. Lo paso?"
            });


            Templates.Add(new WA_Templates()
            {
                Name = "encuesta_docs_2",
                SSID = "HXc9a54789d5464404388010347e832c25",
                Body = @"Queremos ser siempre mejores. Nos puedes ayudar a calificar las instalaciones el día hoy por favor."
            });
        }
    }
    public class WA_Templates
    {
        public string SSID { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
    }
}
