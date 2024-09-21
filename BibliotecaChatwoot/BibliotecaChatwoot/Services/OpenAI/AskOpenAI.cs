using BibliotecaChatwoot.Models.Chatwoot;
using BibliotecaChatwoot.OpenAI;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Services.OpenaAI
{
    public class AskOpenAI
    {
        Config _config;
        OpenAIAPI api;
        public AskOpenAI()
        {
            _config = new Config();
            api = new OpenAI_API.OpenAIAPI(_config.OPENAI_API_KEY);
        }
        public async Task<string> SimpleAsk(string Question)
        {
            
            var result = await api.Chat.CreateChatCompletionAsync(Question);
            return result.ToString();
        }
        public async Task<BotAnswer> BotV1(Messages msgList,bool hasVideo,bool hasIne)
        {
            BotAnswer respuesta = null;
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;
            chat.RequestParameters.Temperature = 0;

            /// give instruction as System
            chat.AppendSystemMessage(@"Eres un agente que atiende whatsapp, tu mision es lograr que el usuario que escribe mande un video y una foto de su ine para obtener un video para una rifa de una moto
                                       Reglas:
                                        0.- Tu primer objetivo es conseguir que el usuario mande el video
                                        0.1.- Tu segundo objetivo es conseguir que el usuario mande foto de su INE
                                        1.- El usuario puede saber que es un bot tu nombre es Terminator
                                        2.- Responde en un lenguaje que un usuario de clase baja pueda entender
                                        3.- Incluye emojis
                                        4.- Cualquier video que mande el usuario se considera valido
                                        5.- Cualquier imagen que mande el video se considera valido
                                        6.- Da formato apropiado para whatsapp como negritas subrallados y mas
                                        8.- Cuando te manden el video da gracias y solicita que me manden una foto de la INE por el frente
                                        9.- Cuando manden la INE dile simplemente 'Gracias' y un true en el campo isDone
                                        10.- Cuando manden su video tendras el texto -el usuario mando video-
                                        11.- Cuando manden su INE tendras el texto -el usuario mando INE-
                                        12.- tu respuesta debe procurar tener emojis
                                        Conocimientos:
                                        1.- Necesitas ser mayor de edad para participar
                                        2.- La rifa sera el 1 de diciembre 2024
                                        3.- La moto a rifar es una vento 2024
                                        4.- Le corresponde al usuario ponerla a su nombre
                                        5.- La moto se entrega fisicamente en nuestras oficinas de guadalajara
                                        6.- Aun no conoces en cual sucursal se hara la entrega
                                        7.- El sorteo es con lo ultimos numeros de la loteria nacional
                                        8.- El video debe respnder 3 preguntas 1.- Cual moto te gustaria tener y para que\n2.- Cuanto ganas y en que trabajas\n3.- Cuentanos una historia en moto
                                        9.- Puedes tener un boleto por tu video;Pero, puedes ganar un boleto adicional por cada amigo que recomiendes
                                        
                                        Formato:
                                        Debes SIEMPRE responder en formato json con esta estructura
                                        {
                                            'Answer':'',
                                            'canAnswer':'',
                                            'isDone':''
                                        }
                                        1.- En answer pones la respuesta que darias
                                        1.1.- En el campo answer se debe responder ocn un formato bonito para whatsapp
                                        1.2.- En el campo answer se deben incluir emojis
                                        1.3.- En el campo answer la respuesta debe ser corta y entendible para personas de bajos recursos
                                        2.- El campo canAnswer es un booleano que dice si crees que pudiste responder la pregunta satisfactoriamente
                                        3.- El campo isDone,es un booleano que dice si en la conversacion ya esta el video y ya esta la INE");

            // give a few examples as user and assistant
            chat.AppendUserInput("Hola quiero una moto");
            chat.AppendExampleChatbotOutput(@"{
                                            'Answer':'Hola! Claro que si, para participar en la rifa de la moto necesitas mandar un video y una foto de tu INE, ¿te gustaria participar? 😉',
                                            'canAnswer':true,
                                            'isDone':false
                                        }");
            chat.AppendUserInput("Necesito licencia de conducir?");
            chat.AppendExampleChatbotOutput(@"{
                                            'Answer':'No lo se',
                                            'canAnswer':false,
                                            'isDone':false
                                        }");
            /*Informo al sistema si ya tiene el video o si ya tiene la INE*/
            if (hasVideo)
            {
                chat.AppendUserInput("El usuario subio el video");
            }
            if (hasIne)
            {
                chat.AppendUserInput("El usuario subio la INE");
            }

            /*Obtengamos la respuesta basada en todos los mensajes que llegaron*/
            foreach (PayloadMSG item in msgList.payload)
            {
                try
                {
                    if (item.sender.type == "contact")
                    {
                        /*Mensaje del usuario*/
                        try
                        {
                            switch (item.attachments.FirstOrDefault().file_type)
                            {
                                case "video":
                                    chat.AppendUserInput("El usuario subio el video");
                                    break;
                                case "image":
                                    chat.AppendUserInput("El usuario subio la INE");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            /*No habia adjuntos*/
                            Console.WriteLine($"No habia adjuntos se ejecuto: chat.AppendUserInput({item.content})");
                            try
                            {
                                chat.AppendUserInput(item.content);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"No se pudo escribir: {item.content}");
                            }
                        }
                    }
                    else
                    {
                            chat.AppendExampleChatbotOutput(JsonConvert.SerializeObject(new BotAnswer()
                            {
                                Answer=item.content,
                                canAnswer=true,
                                isDone=false
                            }) );
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine($"OpenAI error 145: {ex.Message}");
                
                }
            }
            try
            {
                Console.WriteLine("Solicitamos OpenAI ayuda");
                string response = await chat.GetResponseFromChatbotAsync();
                Console.WriteLine($"Respuesta Bruta 153: {JsonConvert.SerializeObject(response)}");
                response = response.Replace("'", "\"");
                respuesta= JsonConvert.DeserializeObject<BotAnswer>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OpenAI error 159: {ex.Message}");
            }

            return respuesta;
        }

    }
}
