using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class ContactFoundModel
    {
        public Meta meta { get; set; }
        public Payload_CFM[] payload { get; set; }
    }


    public class Payload_CFM
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
}
