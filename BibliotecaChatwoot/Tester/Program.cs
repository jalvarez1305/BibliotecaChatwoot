using BibliotecaChatwoot.Models.Chatwoot;
using BibliotecaChatwoot.Services.Chatwoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            CW_Conversation_Service s = new CW_Conversation_Service();
            var msg = @"Hola {{1}}, queremos ser siempre mejores para ti. Nos podrias decir como calificarías la atención brindada por tu medico {{2}}?

            por favor";
            List<string> parametros = new List<string>() { "Pablo", "Rosario" };
            s.EnviaMensajePlantilla(162, msg, parametros, ChatwootSenders.Pacientes);
            //CW_Contacts_Service contacts_Service = new CW_Contacts_Service();
            //var con=contacts_Service.SearchContactById("162");
            //con.payload.custom_attributes.cumple = new DateTime(1986, 05, 18);
            //con.payload.custom_attributes.nickname = "Pablin";
            //contacts_Service.UpdateContactCustomAttributes(con.payload.id,con.payload.custom_attributes);
            Console.ReadLine();
        }
    }
}
