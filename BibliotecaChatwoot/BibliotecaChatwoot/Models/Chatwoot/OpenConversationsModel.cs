using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class OpenConversationsModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Meta meta { get; set; }
        public Payload_OC[] payload { get; set; }
    }


    public class Payload_OC
    {
        public Meta1 meta { get; set; }
        /*Este es el ID de la conversacion*/
        public int id { get; set; }
        public Message[] messages { get; set; }
        public int account_id { get; set; }
        public string uuid { get; set; }
        public Additional_Attributes1 additional_attributes { get; set; }
        public int agent_last_seen_at { get; set; }
        public int assignee_last_seen_at { get; set; }
        public bool can_reply { get; set; }
        public int contact_last_seen_at { get; set; }
        public Custom_Attributes1 custom_attributes { get; set; }
        public int inbox_id { get; set; }
        public object[] labels { get; set; }
        public bool muted { get; set; }
        public object snoozed_until { get; set; }
        public string status { get; set; }
        public int created_at { get; set; }
        public int timestamp { get; set; }
        public int first_reply_created_at { get; set; }
        public int unread_count { get; set; }
        public Last_Non_Activity_Message last_non_activity_message { get; set; }
        public int last_activity_at { get; set; }
        public object priority { get; set; }
        public int waiting_since { get; set; }
    }

    public class Meta1
    {
        public Sender sender { get; set; }
        public string channel { get; set; }
        public Assignee assignee { get; set; }
        public bool hmac_verified { get; set; }
    }





    public class Last_Non_Activity_Message
    {
        public int id { get; set; }
        public string content { get; set; }
        public int account_id { get; set; }
        public int inbox_id { get; set; }
        public int conversation_id { get; set; }
        public int message_type { get; set; }
        public int created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool _private { get; set; }
        public string status { get; set; }
        public object source_id { get; set; }
        public string content_type { get; set; }
        public Content_Attributes content_attributes { get; set; }
        public string sender_type { get; set; }
        public int sender_id { get; set; }
        public External_Source_Ids external_source_ids { get; set; }
        public Additional_Attributes2 additional_attributes { get; set; }
        public string processed_message_content { get; set; }
        public Sentiment sentiment { get; set; }
        public Conversation conversation { get; set; }
        public Sender1 sender { get; set; }
    }



    public class External_Source_Ids1
    {
    }


    public class Sentiment1
    {
    }

}
