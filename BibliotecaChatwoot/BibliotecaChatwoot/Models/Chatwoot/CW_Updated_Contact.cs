using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class CW_Updated_Contact
    {
        public PayloadUpdatedContact payload { get; set; }
    }
    public class PayloadUpdatedContact
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
        public int last_activity_at { get; set; }
        public int created_at { get; set; }
        public Contact_Inboxes[] contact_inboxes { get; set; }
    }
    /*Objetos para actualizar solo un campo*/
    /*VideoURL*/

    public class CW_Update_Video_URL
    {
        public Custom_Attributes_Video custom_attributes { get; set; }
    }

    public class Custom_Attributes_Video
    {
        public bool has_video { get; set; }
        public string video_url { get; set; }
    }

    /*VideoIDS*/
    public class CW_Update_IDs_URL
    {
        public Custom_Attributes_INE custom_attributes { get; set; }
    }

    public class Custom_Attributes_INE
    {
        public bool has_ine { get; set; }

        public string ine_url { get; set; }
    }
}
