using System;
using System.Net;
using System.Text;
using BibliotecaChatwoot.Models.Chatwoot;
using Newtonsoft.Json;
using RestSharp;
using Twilio.Http;

namespace BibliotecaChatwoot.Services.Chatwoot
{
    public enum ContactUpdateFields
    {
        Video,
        ID
    }
    public class CW_Contacts_Service
    {
        Config _config;
        public CW_Contacts_Service()
        {
            _config = new Config();

        }
        public bool Updatecontact(object NewValue, ContactUpdateFields Field,int ContactID)
        {
            bool res = false;
            var client = new RestClient(_config.CW_URL);
            var request = new RestRequest("contacts", Method.Put);
            request.AddHeader("api_access_token", _config.CW_TOKEN);
            request.AddHeader("Content-Type", "application/json");
            request.Resource += $"/{ContactID}";

            var jsonBodyObject = GetBodyObject(Field,NewValue);

            var jsonBody = JsonConvert.SerializeObject(jsonBodyObject);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            Console.WriteLine($"La url para actualizar contacto es: {request.Resource} Metodo: {request.Method}");
            var response = client.Execute(request);
            Console.WriteLine($"Respuesta ContactID:{ContactID}: {response.Content}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res=true;
                Console.WriteLine($"Updates contact: {ContactID}");
            }
            else
            {
                Console.WriteLine($"Error al actualizar el contacto {ContactID}. Código de estado: {response.StatusCode}");
                res=false;
            }
            return res;
        }

        private object GetBodyObject(ContactUpdateFields field, object value)
        {
            object body = null;
            switch (field)
            {
                case ContactUpdateFields.Video:
                    body = new CW_Update_Video_URL()
                    {
                        custom_attributes = new Custom_Attributes_Video()
                        {
                            has_video = true,
                            video_url = value.ToString()
                        }                        
                    };
                    break;
                case ContactUpdateFields.ID:
                    body = new CW_Update_IDs_URL()
                    {
                        custom_attributes = new Custom_Attributes_INE()
                        {
                            has_ine = true,
                            ine_url = value.ToString()
                        }                        
                    };
                    break;
                default:
                    break;
            }
            return body;
        }

        public CW_Created_Contact CreateContact(CW_NEW_CONTACT cw_Contact,int? ContactID=null)
        {
            CW_Created_Contact new_contact = null;
            try
            {
                var client = new RestClient(_config.CW_URL);
                var request = new RestRequest("contacts", ContactID != null ? Method.Put : Method.Post);
                request.AddHeader("api_access_token", _config.CW_TOKEN);
                request.AddHeader("Content-Type", "application/json");
                if (ContactID != null)
                {
                    request.Resource += $"/{ContactID}";
                }

                var jsonBody = JsonConvert.SerializeObject(cw_Contact);
                request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

                Console.WriteLine($"La url para actualizar contacto es: {request.Resource} Metodo: {request.Method}");
                var response = client.Execute(request);
                Console.WriteLine($"Respuesta ContactID:{ContactID}: {response.Content}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (ContactID != null)
                    {
                        /*Cuando era un update*/

                        new_contact = ParseUpdatedToNewContact(response);
                    }
                    else
                    {
                        new_contact = JsonConvert.DeserializeObject<CW_Created_Contact>(response.Content);
                    }
                    if (new_contact.payload.contact.phone_number == null)
                    {
                        /*No se creo un contacto en realidad*/
                        new_contact = null;
                    }
                    Console.WriteLine($"Created contact: {JsonConvert.SerializeObject(new_contact)}");
                }
                else
                {
                    Console.WriteLine($"Error al crear el contacto. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return null;
            }
            return new_contact;
        }

        private CW_Created_Contact ParseUpdatedToNewContact(RestResponse response)
        {
            CW_Updated_Contact contact = JsonConvert.DeserializeObject<CW_Updated_Contact>(response.Content);
            CW_Created_Contact created = new CW_Created_Contact()
            {
                payload = new Payload()
                {
                    contact= new Contact()
                    {
                        custom_attributes=contact.payload.custom_attributes,
                        id=contact.payload.id,
                        name=contact.payload.name,
                        phone_number=contact.payload.phone_number,
                        additional_attributes=contact.payload.additional_attributes,
                        availability_status=contact.payload.availability_status,
                        contact_inboxes=contact.payload.contact_inboxes,
                        created_at=contact.payload.created_at,
                        email=contact.payload.email,
                        identifier=contact.payload.identifier
                    }
                }
            };
            return created;
        }

        public ContactFoundModel SearchContact(string telefono)
        {
            ContactFoundModel found_contact = null;
            try
            {
                var client = new RestClient(_config.CW_URL);
                var request = new RestRequest($"contacts/search?q={telefono}", Method.Get);
                request.AddHeader("api_access_token", _config.CW_TOKEN);
                request.AddHeader("Content-Type", "application/json");

                var response = client.Execute(request);
                Console.WriteLine($"Respuesta de busqueda: {response.Content}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    found_contact = JsonConvert.DeserializeObject<ContactFoundModel>(response.Content);
                }
                else
                {
                    Console.WriteLine($"Error al buscar el contacto. Código de estado: {response.StatusCode}");
                    Console.WriteLine($"Error: {response.Content}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return null;
            }
            return found_contact;
        }
    }

}
