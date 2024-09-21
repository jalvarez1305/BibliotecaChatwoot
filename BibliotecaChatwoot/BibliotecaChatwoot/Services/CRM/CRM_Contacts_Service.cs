using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Data;
using BibliotecasCrediMotos.Models.CRM;
using BibliotecasCrediMotos.Models.Chatwoot;

namespace BibliotecasCrediMotos.Services.CRM
{
    internal class CRM_Contacts_Service
    {
        Config _config;
        string BEARER_TOKEN;
        public CRM_Contacts_Service(string BEARER_TOKEN)
        {
            _config = new Config();
            this.BEARER_TOKEN = BEARER_TOKEN;
        }
        internal bool CREATE_CONTACT(CW_Created_Contact created_contact)
        {
            var response = false;
            #region validations
            string PHONE_NUMBER = created_contact.payload.contact.phone_number.Substring(created_contact.payload.contact.phone_number.Length - _config.PHONES_LENGH);
            if (PHONE_NUMBER.Length!= _config.PHONES_LENGH)
            {
                /*el numero no viene en formato correcto*/
                response = false;
                throw new CustomExceptions("El telefono se debe proporcionar a 10 digitos");
            }
            else
            {
                if (!new Helpers().AreAllDigits(PHONE_NUMBER))
                {
                    /*hay caracteres que no son numeros*/
                    response = false;
                    throw new CustomExceptions("El telefono deben ser solo numeros");
                }
                else
                {
                    /*validar que no exista ya el contacto*/
                    if (GetContactByPhoneNumber(PHONE_NUMBER) != null)
                    {
                        /*contact allready exist*/
                        response = false;
                        throw new CustomExceptions("Ese telefono ya existe");
                    }
                    else
                    {
                        /*como no existe lo creamos*/
                        Create_New_contact(created_contact);
                        response = true;
                    }
                }
            }           
            
            #endregion
           
            return response;
        }
        internal CRMContact GetContactByPhoneNumber(string phoneNumber)
        {
            var client = new RestClient($"{_config.BASE_URL}/V8");
            var request = new RestRequest("module/Contacts", Method.Get);
            request.AddParameter("filter[phone_mobile][eq]", $"52{phoneNumber}");
            // Agregar el token de autenticación en el encabezado
            request.AddHeader("Authorization", $"Bearer {BEARER_TOKEN}");
            CRMContact contact = null;
            try
            {
                var response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    contact = null;
                }

                contact = JsonConvert.DeserializeObject<CRMContact>(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            var cant = contact.data.Count();
            return cant > 0 ? contact:null;        
        }
        private bool Create_New_contact(CW_Created_Contact created_contact)
        {
            
            try
            {
                CRM_New_Contact contact = new CRM_New_Contact()
                {
                    data = new Models.CRM.Data()
                    {
                        attributes = new Attributes_new()
                        {
                            first_name = created_contact.payload.contact.name,
                            phone_mobile = $"52{created_contact.payload.contact.phone_number.Substring(created_contact.payload.contact.phone_number.Length - _config.PHONES_LENGH)}",
                            email1 = $"{created_contact.payload.contact.phone_number.Substring(created_contact.payload.contact.phone_number.Length - _config.PHONES_LENGH)}@credi-motos.com",
                            gender_c = created_contact.payload.contact.custom_attributes.gender,
                            uuid_c = created_contact.payload.contact.id.ToString("x"),
                            refered_by_c = created_contact.payload.contact.custom_attributes.refered_by,
                            campaign_id= created_contact.payload.contact.custom_attributes.campaign_id
                        }
                    }
                };
                


                var client = new RestClient(_config.BASE_URL);
                var request = new RestRequest("V8/module", Method.Post);
                request.AddHeader("Authorization", $"Bearer {BEARER_TOKEN}");
                request.AddHeader("Content-Type", "application/json");
                /*Formateo la data*/

                var postData = contact;
                request.AddJsonBody(postData);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Console.WriteLine("Contacto creado exitosamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al crear el contacto. Código de estado: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return false;
            }            
        }
    }
}
