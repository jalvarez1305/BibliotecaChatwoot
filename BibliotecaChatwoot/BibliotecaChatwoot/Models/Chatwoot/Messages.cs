using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{


    public class Messages
    {
        public Meta meta { get; set; }
        public PayloadMSG[] payload { get; set; }
    }

    public class Meta
    {
        public object[] labels { get; set; }
        public Additional_Attributes additional_attributes { get; set; }
        public Contact contact { get; set; }
        public Assignee assignee { get; set; }
        public DateTime? agent_last_seen_at { get; set; }
        public DateTime? assignee_last_seen_at { get; set; }
    }



    public class Additional_Attributes1
    {
    }


    public class Assignee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string available_name { get; set; }
        public string avatar_url { get; set; }
        public string type { get; set; }
        public string availability_status { get; set; }
        public string thumbnail { get; set; }
    }

    public class PayloadMSG
    {
        public int id { get; set; }
        public string content { get; set; }
        public int inbox_id { get; set; }
        public int conversation_id { get; set; }
        public int message_type { get; set; }
        public string content_type { get; set; }
        public string status { get; set; }
        public Content_Attributes content_attributes { get; set; }
        public int created_at { get; set; }
        public bool _private { get; set; }
        public string source_id { get; set; }
        public Sender sender { get; set; }
        public Attachment[] attachments { get; set; }
    }

    public class Content_Attributes
    {
    }

    public class Sender
    {
        public Additional_Attributes2 additional_attributes { get; set; }
        public Custom_Attributes1 custom_attributes { get; set; }
        public object email { get; set; }
        public int id { get; set; }
        public object identifier { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string thumbnail { get; set; }
        public string type { get; set; }
        public string available_name { get; set; }
        public string avatar_url { get; set; }
        public string availability_status { get; set; }
    }

    public class Additional_Attributes2
    {
    }

    public class Custom_Attributes1
    {
    }

    public class Attachment
    {
        public int id { get; set; }
        public int message_id { get; set; }
        /*image,video*/
        public string file_type { get; set; }
        public int account_id { get; set; }
        public object extension { get; set; }
        public string data_url { get; set; }
        public string thumb_url { get; set; }
        public int file_size { get; set; }
    }

}
