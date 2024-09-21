using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.Models.Chatwoot
{
    public class CW_WH_MessageCreated
    {
        /*El objeto que manda en el body chatwoot en el webhook MessageCreated*/
        public Account account { get; set; }
        public Additional_Attributes additional_attributes { get; set; }
        public Content_Attributes content_attributes { get; set; }
        public string content_type { get; set; }
        public string content { get; set; }
        public Conversation conversation { get; set; }
        public DateTime? created_at { get; set; }
        public int id { get; set; }
        public Inbox inbox { get; set; }
        public string message_type { get; set; }
        public bool _private { get; set; }
        public Sender2 sender { get; set; }
        public string source_id { get; set; }
        public string _event { get; set; }
    }

    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
    }


    public class Conversation
    {
        public Additional_Attributes1 additional_attributes { get; set; }
        public bool can_reply { get; set; }
        public string channel { get; set; }
        public Contact_Inbox contact_inbox { get; set; }
        public int id { get; set; }
        public int inbox_id { get; set; }
        public Message[] messages { get; set; }
        public object[] labels { get; set; }
        public Meta meta { get; set; }
        public string status { get; set; }
        public Custom_Attributes1 custom_attributes { get; set; }
        public object snoozed_until { get; set; }
        public int unread_count { get; set; }
        public DateTime? first_reply_created_at { get; set; }
        public object priority { get; set; }
        public int waiting_since { get; set; }
        public int agent_last_seen_at { get; set; }
        public int contact_last_seen_at { get; set; }
        public int timestamp { get; set; }
        public int created_at { get; set; }
    }




    public class Content_Attributes1
    {
    }

    public class External_Source_Ids
    {
    }

    public class Additional_Attributes3
    {
    }

    public class Sentiment
    {
    }

    public class Conversation1
    {
        public int assignee_id { get; set; }
        public int unread_count { get; set; }
        public int last_activity_at { get; set; }
        public Contact_Inbox1 contact_inbox { get; set; }
    }

    public class Contact_Inbox1
    {
        public string source_id { get; set; }
    }

    public class Sender1
    {
        public Additional_Attributes4 additional_attributes { get; set; }
        public Custom_Attributes2 custom_attributes { get; set; }
        public object email { get; set; }
        public int id { get; set; }
        public object identifier { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string thumbnail { get; set; }
        public string type { get; set; }
    }

    public class Additional_Attributes4
    {
    }

    public class Custom_Attributes2
    {
    }


    public class Sender2
    {
        public Account1 account { get; set; }
        public Additional_Attributes5 additional_attributes { get; set; }
        public string avatar { get; set; }
        public Custom_Attributes custom_attributes { get; set; }
        public object email { get; set; }
        public int id { get; set; }
        public object identifier { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string thumbnail { get; set; }
    }

    public class Account1
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Additional_Attributes5
    {
    }
}
