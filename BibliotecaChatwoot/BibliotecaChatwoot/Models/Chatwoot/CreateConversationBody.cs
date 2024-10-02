using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class CreateConversationBody
    {
        public int inbox_id { get; set; } = 2;
        public int contact_id { get; set; }
        public string status { get; set; } = "open";
        public Message message { get; set; }
    }
    public class CreateConversationBodyBot
    {
        public int inbox_id { get; set; } = 2;
        public int contact_id { get; set; }
        public string status { get; set; } = "open";
        public Message message { get; set; }
        public BotAttributes custom_attributes { get; set; }
    }
    public class BotAttributes
    {
        public string bot { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
        public Template_Params template_params { get; set; }
    }

    public class Template_Params
    {
        public string name { get; set; } = "sorteo_240430";
        public string category { get; set; } = "UTILITY";
        public string language { get; set; } = "en_US";
        public Processed_Params processed_params { get; set; }
    }

    public class Processed_Params
    {
        public string Orlans { get; set; } = "Orlans";
    }

}
