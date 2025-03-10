﻿using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using BibliotecaChatwoot.Models.Chatwoot;
using BibliotecaChatwoot.Models;
using Twilio.Http;
using System.Text;
using BibliotecaChatwoot.Services.Twilio;

namespace BibliotecaChatwoot.Services.Chatwoot
{
    public class CW_Conversation_Service
    {
        Config _config;
        private readonly RestClient client;
        TW_Services tw_Services;
        public CW_Conversation_Service()
        {
            _config = new Config();
            client = new RestClient(_config.CW_URL);
            tw_Services = new TW_Services();
        }
        public Messages GetMessagesFromConversation(int ConversationID)
        {

            var request = new RestRequest($"/conversations/{ConversationID}/messages", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Mensajes extraidos con exito.");
            }
            else
            {
                Console.WriteLine($"Error al enviar mensaje: {response.ErrorMessage}");
            }
            Messages msg_list=null;
            try
            {
                msg_list = JsonConvert.DeserializeObject<Messages>(response.Content);
            }catch(Exception ex) 
            {

                Console.WriteLine($"Excepcion: {ex.Message}");
                Console.WriteLine($"Error con el objeto: {response.Content}"); 
            }
            return msg_list;    
        }
        public int GetOpenConversation(int ContactID)
        {
            int conv_id = 0;
            var request = new RestRequest($"/conversations?status=open", Method.Get);
            //request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Mensajes extraidos con exito.");
            }
            else
            {
                Console.WriteLine($"Error al enviar mensaje: {response.ErrorMessage}");
            }
            try
            {
                conv_id = GetConvFromContact(response.Content, ContactID);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion: {ex.Message}");
            }
            return conv_id;
        }

        private int GetConvFromContact(string content, int contactID)
        {
            var conv_list = JsonConvert.DeserializeObject<OpenConversationsModel>(content);
            int conv = 0;
            foreach (var item in conv_list.data.payload)
            {
                if (item.meta.sender.id==contactID)
                {
                    conv = item.id;
                    break;
                }
                else
                {
                    /*Do nothing*/
                }
            }
            return conv;
        }
        public void ReabrirConversacion(int ConvID)
        {
            // Crear el contenido del body (JSON)
            var jsonContent = new System.Net.Http.StringContent("{ \"status\": \"open\" }", Encoding.UTF8, "application/json");


            var request = new RestRequest($"/conversations/{ConvID}/toggle_status", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            request.AddJsonBody(jsonContent);

            var response = client.Execute(request);
            Console.WriteLine($"La respuesta al cambiar estaus fue: {JsonConvert.SerializeObject(response)}");

            if (response.IsSuccessful)
            {
                Console.WriteLine("Estatus cambiado con éxito.");
            }
            else
            {
                Console.WriteLine($"Error al cambiar el estatus: {response.ErrorMessage}");
            }
        }
        public void CerrarConversacion(int ConvID)
        {
            // Crear el contenido del body (JSON)
            var jsonContent = new System.Net.Http.StringContent("{ \"status\": \"resolved\" }", Encoding.UTF8, "application/json");


            var request = new RestRequest($"/conversations/{ConvID}/toggle_status", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            request.AddJsonBody(jsonContent);

            var response = client.Execute(request);
            Console.WriteLine($"La respuesta al cambiar estaus fue: {JsonConvert.SerializeObject(response)}");

            if (response.IsSuccessful)
            {
                Console.WriteLine("Estatus cambiado con éxito.");
            }
            else
            {
                Console.WriteLine($"Error al cambiar el estatus: {response.ErrorMessage}");
            }
        }
        public void EnviaMensajePlantilla(int contactoId,string phoneNumber, WA_Templates Template, List<string> Parametros, ChatwootSenders buzon= ChatwootSenders.Pacientes,string BotName=null)
        {
            Dictionary<string, object> tw_params = new Dictionary<string, object>();
            if (Parametros==null)
            {
                Parametros = new List<string>();
            }
            else
            {
                tw_params =FormateaParametros(Parametros);
            }
            Console.WriteLine($"Cantidad de parametros: {Parametros.Count} Texto: {Template.Body} al contacto: {contactoId} desde: {buzon}");
            string TextToSend = Template.Body;
            for (int ii = 0; ii < Parametros.Count; ii++)
            {
                int jj = ii + 1;
                TextToSend = TextToSend.Replace($"{{{{{jj}}}}}", Parametros[ii]);
            }
            Console.WriteLine($"El mensaje a enviar es: {TextToSend}");
            int open_conv = GetOpenConversation(contactoId);
            if (BotName != null)
            {
                /*Si para mandar plantilla se incluye un Bot, se tiene que iniciar una nueva conversacion*/
                CerrarConversacion(open_conv);
                open_conv = 0;
            }
            else
            {
                /*do nothing*/
                /*Se sigue la logica normal*/
            }
            /*Sin importar conv abierta o cerrada hay que mandar primero el mensaje por whatsapp*/
            tw_Services.SendTemplateAsync(phoneNumber, Template.SSID, tw_params);
            if (open_conv > 0)
            {
                Console.WriteLine($"Se enla conversacion: {open_conv}");                
                SendConversationMessage(open_conv, TextToSend,buzon: buzon,is_private:true);

            }
            else
            {
                var request = new RestRequest($"/conversations", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("api_access_token", _config.CW_TOKEN);
                if (BotName==null)
                {
                    var conversation = new CreateConversationBody()
                    {
                        contact_id = contactoId,
                        inbox_id= (int)buzon,
                        message = new Message()
                        {
                            content = TextToSend,
                            @private = true
                        }                    
                    };
                    request.AddJsonBody(conversation);
                }
                else
                {
                    var conversation = new CreateConversationBodyBot()
                    {
                        contact_id = contactoId,
                        inbox_id = (int)buzon,
                        message = new Message()
                        {
                            content = TextToSend,
                            @private = true
                        },
                        custom_attributes= new BotAttributes() { bot=BotName}
                    };
                    request.AddJsonBody(conversation);
                }


                var response = client.Execute(request);
                Console.WriteLine($"La respuesta al enviar la plantilla fue: {JsonConvert.SerializeObject(response)}");

                if (response.IsSuccessful)
                {
                    var conversationResponse = JsonConvert.DeserializeObject<ConversationResponse>(response.Content);
                    if (conversationResponse != null && conversationResponse.status == "resolved")
                    {
                        ReabrirConversacion(conversationResponse.id);
                    }
                    else
                    {
                        /*do nothing*/
                    }
                    Console.WriteLine("Mensaje enviado con éxito.");
                }
                else
                {
                    Console.WriteLine($"Error al enviar mensaje: {response.ErrorMessage}");
                }
            }
        }

        private Dictionary<string, object> FormateaParametros(List<string> parametros)
        {
            var parametrosDiccionario = new Dictionary<string, object>();

            for (int i = 0; i < parametros.Count; i++)
            {
                parametrosDiccionario.Add((i + 1).ToString(), parametros[i]);
            }
            return parametrosDiccionario;
        }

        public void SendConversationMessage(int ConversationID, string message,bool is_private=false, ChatwootSenders buzon= ChatwootSenders.Pacientes)
        {
            Console.WriteLine($"Enviando: {ConversationID} Msg:{message}");
            var request = new RestRequest($"/conversations/{ConversationID}/messages", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            request.AddJsonBody(new CreateMessage()
            {
                content=message,
                @private=is_private
            });

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Mensaje enviado con éxito.{response.Content}");
            }
            else
            {
                Console.WriteLine($"Error al enviar mensaje: {response.ErrorMessage}");
            }
        }
        public void AssignConversation(int ConversationID)
        {
            Console.WriteLine($"Asignando: {ConversationID}");
            var request = new RestRequest($"/conversations/{ConversationID}/assignments", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            request.AddJsonBody(new AssignConversationModel());

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Conversacion asignada con exito");
            }
            else
            {
                Console.WriteLine($"Error al asignar conversacion: {response.ErrorMessage}");
            }
        }
    }
}
