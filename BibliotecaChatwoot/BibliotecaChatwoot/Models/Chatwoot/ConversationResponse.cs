using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{

    public class ConversationResponse
    {
        public Meta meta { get; set; }
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
        public object sla_policy_id { get; set; }
    }



    public class Social_Profiles
    {
        public string github { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string linkedin { get; set; }
        public string instagram { get; set; }
    }




    public class Template_Params1
    {
        public string name { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public Processed_Params1 processed_params { get; set; }
    }

    public class Processed_Params1
    {
        public string Orlans { get; set; }
    }

}
