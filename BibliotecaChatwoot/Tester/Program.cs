﻿using BibliotecaChatwoot.Models.Chatwoot;
using BibliotecaChatwoot.Services.Chatwoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BibliotecaChatwoot.Services.Twilio;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CW_Conversation_Service s = new CW_Conversation_Service();
            //var msg = "Hola, buenos días. Tienes un momento?";
            //List<string> parametros = new List<string>() { "Pablo", "Rosario" };
            ////s.EnviaMensajePlantilla(162, msg, parametros, ChatwootSenders.Pacientes,BotName:"EncuestaBot");
            //s.EnviaMensajePlantilla(162, msg, parametros, ChatwootSenders.Pacientes);
            ////CW_Contacts_Service contacts_Service = new CW_Contacts_Service();
            ////var con=contacts_Service.SearchContactById("162");
            ////con.payload.custom_attributes.cumple = new DateTime(1986, 05, 18);
            ////con.payload.custom_attributes.nickname = "Pablin";
            ////contacts_Service.UpdateContactCustomAttributes(con.payload.id,con.payload.custom_attributes);
            //Console.ReadLine();
            var config = new BibliotecaChatwoot.Services.Twilio.Config();

            // Buscar el template con el nombre "encuesta_pacientes"
            var template = config.Templates.FirstOrDefault(t => t.Name == "encuesta_pacientes");
            List<string> par = new List<string>() { "Pablin", "Dra. Lupita" };
            s.EnviaMensajePlantilla(162, "+523331830952", template, par);
        }
    }
}
