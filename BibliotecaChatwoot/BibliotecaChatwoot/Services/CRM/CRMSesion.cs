using BibliotecasCrediMotos.Models.Chatwoot;
using BibliotecasCrediMotos.Models.CRM;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.Services.CRM
{
    public class CRMSesion
    {
        private string TOKEN;
        Config _config = new Config();
        public CRMSesion()
        {
            TOKEN = GetAccessToken();
        }

        private string GetAccessToken()
        {
            var client = new RestClient(_config.BASE_URL);
            var request = new RestRequest("/access_token", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            // Añadir los datos necesarios para la petición
            var body = new Access_Token_Body();

            request.AddJsonBody(body);

            try
            {
                var response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    return null;
                }

                // Deserializar y obtener el token usando Newtonsoft.Json
                var responseObject = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                return responseObject.access_token;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return null;
            }
        }
        public string ShowToken()
        {
            return TOKEN;
        }
        public bool CreateContact(CW_Created_Contact created_contact)
        {
            var result = false;
            CRM_Contacts_Service contacts = new CRM_Contacts_Service(TOKEN);
            result=contacts.CREATE_CONTACT(created_contact);

            return result;
        }
        public bool GetContactByPhoneNumber(string phoneNumber)
        {
            var contacts = new CRM_Contacts_Service(TOKEN);
            return contacts.GetContactByPhoneNumber(phoneNumber)!=null;
        }
    }
}
