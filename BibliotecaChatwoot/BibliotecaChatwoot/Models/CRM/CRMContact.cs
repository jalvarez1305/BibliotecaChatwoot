using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibliotecasCrediMotos.Models.CRM
{
    public class ZeroOrFalseConverter : JsonConverter<bool>
    {
        public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Verificar si el valor es 0 y convertirlo a falso, de lo contrario, utilizar el valor predeterminado
            if (reader.TokenType == JsonToken.Integer)
            {
                var value = Convert.ToInt32(reader.Value);
                return value == 0 ? false : existingValue;
            }
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
    public class CRMContact
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string type { get; set; } = "Contacts";
        public string id { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
    }

    public class Attributes
    {
        /*Currently used 2024-04-29*/
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string phone_mobile { get; set; }
        public string email1 { get; set; }
        public string description { get; set; }
        public string gender_c { get; set; } = "Masculino";
        public string uuid_c { get; set; }
        public string refered_by_c { get; set; }

        [JsonConverter(typeof(ZeroOrFalseConverter))]
        public bool has_video_c { get; set; } = false;
        [JsonConverter(typeof(ZeroOrFalseConverter))]
        public bool has_valid_video_c { get; set; } = false;
        [JsonConverter(typeof(ZeroOrFalseConverter))]
        public bool has_ine_c { get; set; } = false;
        [JsonConverter(typeof(ZeroOrFalseConverter))]
        public bool has_valid_ine_c { get; set; } = false;
        public string ine_url_c { get; set; }
        public string video_url_c { get; set; }
        public string campaign_name { get; set; }
        public string campaign_id { get; set; }
        /**/
        public string name { get; set; }
        public DateTime date_entered { get; set; }
        public DateTime date_modified { get; set; }
        public string modified_user_id { get; set; }
        public string modified_by_name { get; set; }
        public string created_by { get; set; }
        public string created_by_name { get; set; }
        public string deleted { get; set; }
        public string created_by_link { get; set; }
        public string modified_user_link { get; set; }
        public string assigned_user_id { get; set; }
        public string assigned_user_name { get; set; }
        public string assigned_user_link { get; set; }
        public string SecurityGroups { get; set; }
        public string salutation { get; set; }
        public string title { get; set; }
        public string photo { get; set; }
        public string department { get; set; }
        public string do_not_call { get; set; }
        public string phone_home { get; set; }
        public string email { get; set; }
        public string phone_work { get; set; }
        public string phone_other { get; set; }
        public string phone_fax { get; set; }
        public string email2 { get; set; }
        public string invalid_email { get; set; }
        public string email_opt_out { get; set; }
        public string lawful_basis { get; set; }
        public string date_reviewed { get; set; }
        public string lawful_basis_source { get; set; }
        public string primary_address_street { get; set; }
        public string primary_address_street_2 { get; set; }
        public string primary_address_street_3 { get; set; }
        public string primary_address_city { get; set; }
        public string primary_address_state { get; set; }
        public string primary_address_postalcode { get; set; }
        public string primary_address_country { get; set; }
        public string alt_address_street { get; set; }
        public string alt_address_street_2 { get; set; }
        public string alt_address_street_3 { get; set; }
        public string alt_address_city { get; set; }
        public string alt_address_state { get; set; }
        public string alt_address_postalcode { get; set; }
        public string alt_address_country { get; set; }
        public string assistant { get; set; }
        public string assistant_phone { get; set; }
        public string email_addresses_primary { get; set; }
        public string email_addresses { get; set; }
        public string email_addresses_non_primary { get; set; }
        public string email_and_name1 { get; set; }
        public string lead_source { get; set; }
        public string account_name { get; set; }
        public string account_id { get; set; }
        public string opportunity_role_fields { get; set; }
        public string opportunity_role_id { get; set; }
        public string opportunity_role { get; set; }
        public string reports_to_id { get; set; }
        public string report_to_name { get; set; }
        public string birthdate { get; set; }
        public string accounts { get; set; }
        public Reports_To_Link reports_to_link { get; set; }
        public string opportunities { get; set; }
        public string bugs { get; set; }
        public string calls { get; set; }
        public string cases { get; set; }
        public string direct_reports { get; set; }
        public string emails { get; set; }
        public string documents { get; set; }
        public string leads { get; set; }
        public string meetings { get; set; }
        public string notes { get; set; }
        public string project { get; set; }
        public string project_resource { get; set; }
        public string am_projecttemplates_resources { get; set; }
        public string am_projecttemplates_contacts_1 { get; set; }
        public string tasks { get; set; }
        public string tasks_parent { get; set; }
        public string notes_parent { get; set; }
        public User_Sync user_sync { get; set; }
        public string campaigns { get; set; }
        public string campaign_contacts { get; set; }
        public string c_accept_status_fields { get; set; }
        public string m_accept_status_fields { get; set; }
        public string accept_status_id { get; set; }
        public string accept_status_name { get; set; }
        public string prospect_lists { get; set; }
        public string sync_contact { get; set; }
        public string fp_events_contacts { get; set; }
        public string aos_quotes { get; set; }
        public string aos_invoices { get; set; }
        public string aos_contracts { get; set; }
        public string e_invite_status_fields { get; set; }
        public string event_status_name { get; set; }
        public string event_invite_id { get; set; }
        public string e_accept_status_fields { get; set; }
        public string event_accept_status { get; set; }
        public string event_status_id { get; set; }
        public string project_contacts_1 { get; set; }
        public string aop_case_updates { get; set; }
        public string joomla_account_id { get; set; }
        public bool portal_account_disabled { get; set; }
        public string joomla_account_access { get; set; }
        public string portal_user_type { get; set; }
        public string jjwg_maps_lng_c { get; set; }
        public string jjwg_maps_lat_c { get; set; }
        public string jjwg_maps_geocode_status_c { get; set; }
        public string jjwg_maps_address_c { get; set; }
    }

    public class Reports_To_Link
    {
    }

    public class User_Sync
    {
    }

    public class Relationships
    {
        public AM_Projecttemplates AM_ProjectTemplates { get; set; }
        public AOS_Contracts AOS_Contracts { get; set; }
        public AOS_Invoices AOS_Invoices { get; set; }
        public AOS_Quotes AOS_Quotes { get; set; }
        public Campaignlog CampaignLog { get; set; }
        public Emailaddress EmailAddress { get; set; }
        public Opportunities Opportunities { get; set; }
        public Project Project { get; set; }
        public Prospectlists ProspectLists { get; set; }
        public Securitygroups SecurityGroups { get; set; }
        public Users Users { get; set; }
    }

    public class AM_Projecttemplates
    {
        public Links links { get; set; }
    }

    public class Links
    {
        public string related { get; set; }
    }

    public class AOS_Contracts
    {
        public Links1 links { get; set; }
    }

    public class Links1
    {
        public string related { get; set; }
    }

    public class AOS_Invoices
    {
        public Links2 links { get; set; }
    }

    public class Links2
    {
        public string related { get; set; }
    }

    public class AOS_Quotes
    {
        public Links3 links { get; set; }
    }

    public class Links3
    {
        public string related { get; set; }
    }

    public class Campaignlog
    {
        public Links4 links { get; set; }
    }

    public class Links4
    {
        public string related { get; set; }
    }

    public class Emailaddress
    {
        public Links5 links { get; set; }
    }

    public class Links5
    {
        public string related { get; set; }
    }

    public class Opportunities
    {
        public Links6 links { get; set; }
    }

    public class Links6
    {
        public string related { get; set; }
    }

    public class Project
    {
        public Links7 links { get; set; }
    }

    public class Links7
    {
        public string related { get; set; }
    }

    public class Prospectlists
    {
        public Links8 links { get; set; }
    }

    public class Links8
    {
        public string related { get; set; }
    }

    public class Securitygroups
    {
        public Links9 links { get; set; }
    }

    public class Links9
    {
        public string related { get; set; }
    }

    public class Users
    {
        public Links10 links { get; set; }
    }

    public class Links10
    {
        public string related { get; set; }
    }

}
