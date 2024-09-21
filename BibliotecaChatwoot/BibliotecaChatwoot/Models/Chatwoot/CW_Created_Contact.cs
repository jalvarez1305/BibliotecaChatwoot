using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class CW_Created_Contact
    {
        public Payload payload { get; set; }
    }

    public class Payload
    {
        public Contact contact { get; set; }
        public Contact_Inbox contact_inbox { get; set; }
    }

    public class Contact
    {
        public Additional_Attributes additional_attributes { get; set; }
        public string availability_status { get; set; }
        public object email { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public object identifier { get; set; }
        public string thumbnail { get; set; }
        public Custom_Attributes custom_attributes { get; set; }
        public int created_at { get; set; }
        public Contact_Inboxes[] contact_inboxes { get; set; }
    }

    public class Additional_Attributes
    {
    }

    public class Custom_Attributes
    {
        public string gender { get; set; }
        public string uuid { get; set; }
        public string refered_by { get; set; }
        public bool has_video { get; set; }
        public bool has_valid_video { get; set; }
        public bool has_ine { get; set; }
        public bool has_valid_ine { get; set; }
        public string ine_url { get; set; }
        public string video_url { get; set; }
        public string campaign_name { get; set; }
        public string campaign_id { get; set; }
    }

    public class Contact_Inboxes
    {
        public string source_id { get; set; }
        public Inbox inbox { get; set; }
    }

    public class Inbox
    {
        public int id { get; set; }
        public string avatar_url { get; set; }
        public int channel_id { get; set; }
        public string name { get; set; }
        public string channel_type { get; set; }
        public bool greeting_enabled { get; set; }
        public string greeting_message { get; set; }
        public bool working_hours_enabled { get; set; }
        public bool enable_email_collect { get; set; }
        public bool csat_survey_enabled { get; set; }
        public bool enable_auto_assignment { get; set; }
        public Auto_Assignment_Config auto_assignment_config { get; set; }
        public string out_of_office_message { get; set; }
        public Working_Hours[] working_hours { get; set; }
        public string timezone { get; set; }
        public string callback_webhook_url { get; set; }
        public bool allow_messages_after_resolved { get; set; }
        public bool lock_to_single_conversation { get; set; }
        public string sender_name_type { get; set; }
        public object business_name { get; set; }
        public object widget_color { get; set; }
        public object website_url { get; set; }
        public object hmac_mandatory { get; set; }
        public object welcome_title { get; set; }
        public object welcome_tagline { get; set; }
        public object web_widget_script { get; set; }
        public object website_token { get; set; }
        public object selected_feature_flags { get; set; }
        public object reply_time { get; set; }
        public object messaging_service_sid { get; set; }
        public string phone_number { get; set; }
        public string medium { get; set; }
        public object provider { get; set; }
    }

    public class Auto_Assignment_Config
    {
    }

    public class Working_Hours
    {
        public int day_of_week { get; set; }
        public bool closed_all_day { get; set; }
        public int? open_hour { get; set; }
        public int? open_minutes { get; set; }
        public int? close_hour { get; set; }
        public int? close_minutes { get; set; }
        public bool open_all_day { get; set; }
    }

    public class Contact_Inbox
    {
        public Inbox1 inbox { get; set; }
        public string source_id { get; set; }
    }

    public class Inbox1
    {
        public int id { get; set; }
        public int channel_id { get; set; }
        public int account_id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string channel_type { get; set; }
        public bool enable_auto_assignment { get; set; }
        public bool greeting_enabled { get; set; }
        public string greeting_message { get; set; }
        public object email_address { get; set; }
        public bool working_hours_enabled { get; set; }
        public string out_of_office_message { get; set; }
        public string timezone { get; set; }
        public bool enable_email_collect { get; set; }
        public bool csat_survey_enabled { get; set; }
        public bool allow_messages_after_resolved { get; set; }
        public Auto_Assignment_Config1 auto_assignment_config { get; set; }
        public bool lock_to_single_conversation { get; set; }
        public object portal_id { get; set; }
        public string sender_name_type { get; set; }
        public object business_name { get; set; }
    }

    public class Auto_Assignment_Config1
    {
    }

}
