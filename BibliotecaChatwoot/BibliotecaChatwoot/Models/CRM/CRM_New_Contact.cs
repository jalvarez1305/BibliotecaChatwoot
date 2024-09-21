using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.Models.CRM
{

    public class CRM_New_Contact
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string type { get; set; } = "Contacts";
        public Attributes_new attributes { get; set; }
    }

    public class Attributes_new
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_mobile { get; set; }
        public string email1 { get; set; }
        public string description { get; set; }
        public string gender_c { get; set; }
        public string uuid_c { get; set; }
        public string refered_by_c { get; set; }
        public bool has_video_c { get; set; }
        public bool has_valid_video_c { get; set; }
        public bool has_ine_c { get; set; }
        public bool has_valid_ine_c { get; set; }
        public string ine_url_c { get; set; }
        public string video_url_c { get; set; }
        public string campaign_name { get; set; }
        public string campaign_id { get; set; }
    }

}
