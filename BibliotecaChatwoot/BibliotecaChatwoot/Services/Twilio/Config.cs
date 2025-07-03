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
        public string authToken { get; set; } = "805b9a728db2f681c0af7310a340d035";
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
                Name = "paciente_presentev2",
                SSID = "HX0863fe50ac30027ffce6185986f0e578",
                Body = @"Hola, buen día. Su paciente {{1}} de las {{2}} ya llego, viene por: 

{{3}}.

Lo paso?"
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
