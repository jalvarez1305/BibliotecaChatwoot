using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI_API.Images;
using System.Buffers.Text;
using BibliotecasCrediMotos.Models.Airtable;
using System.Runtime.Intrinsics.X86;
using Twilio.Http;
using Twilio.TwiML.Voice;
using Helpers;
using System.Net.Sockets;

namespace BibliotecasCrediMotos.Services.Airtable
{
    /* https://github.com/ngocnicholas/airtable.net/wiki/Documentation */
    public class Videos_Table_Service
    {
        Config _config;
        SQL_Helper sql_Helper;
        public Videos_Table_Service()
        {
            _config = new Config();
            sql_Helper = new SQL_Helper();
        }
        public async Task<int?> ObtenerBoleto(string UUID,string Refenrecia)
        {
            int? numero_rifa = null;
            /*Primero hay que buscar el numero que le corresponde*/
            int nextTicket = GetLastTicket();
            nextTicket++;
            CreateRecord(UUID, Refenrecia, nextTicket);
            return nextTicket;
        }

        private int GetLastTicket()
        {
            string cmd = "select max(Boleto) from [dbo].[Boletos]";
            var last_ticket = sql_Helper.ExecutaEscalar(cmd);
            int respuesta = 0;
            Int32.TryParse(last_ticket.ToString(), out respuesta);
            return respuesta;
        }

        public void CreateRecord(string uuid,string uuid_referencia,int ticket)
        {
            string cmd = @$"INSERT INTO [dbo].[Boletos]
                                       ([UUID]
                                       ,[UUID_Referencia]
                                       ,[Boleto])
                                 VALUES
                                       ('{uuid}'
                                       ,'{uuid_referencia}'
                                       ,{ticket})";
            sql_Helper.ExecutaEscalar(cmd);
        }
    }
}
