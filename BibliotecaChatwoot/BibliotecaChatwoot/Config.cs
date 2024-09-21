using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot
{
    internal class Config
    {
        /*SUITE CRM*/
        internal string BASE_URL { get; } = "https://crm.credi-motos.com/legacy/Api";
        internal int PHONES_LENGH { get; } = 10;/*Los telefonos se manejan a 10 digitos fuera de esta bibloteca*/

        /*Chatwoot*/
        internal string CW_URL { get; } = "https://whatsapp.credi-motos.com/api/v1/accounts/1";
        public string CW_TOKEN { get; set; } = "iz5ZxThF8MZSMPSY6GbsdsJC";
        /*OpenAI*/
        public string OPENAI_API_KEY { get; set; } = "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";
        /*S3*/
        public string BUCKET_NAME { get; set; } = "cm-ws-data";
        public string VIDEO_PREFIX { get; set; } = "Video/";
        public string IDS_PREFIX { get; set; } = "IDs/";
        public string BUCKET_REGION { get; set; } = "us-west-1";
        /*AWS*/
        public string AWS_KEY { get; set; } = "AKIAVRUVS5DXTCEFJQGQ";
        public string AWS_SECRET { get; set; } = "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";
        /*AirTable*/
        public string AIRTABLE_VIDEOS_TOKEN { get; } = "path40QrniNFiwAEN.0a50fa280017688168025f02e6f2ab6f361c2146466949f3bd27345122cf338c";
        public string AIRTABLE_BASEID { get; set; } = "appMidDcWNWmUd8An";/*CM_Videos*/
        public string ARTABLE_TABLE_NAME { get; set; } = "Boletos";
    }
}
