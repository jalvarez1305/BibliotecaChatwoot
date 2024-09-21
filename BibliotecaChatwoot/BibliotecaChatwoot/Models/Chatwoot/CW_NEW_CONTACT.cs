using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Chatwoot
{
    public class CW_NEW_CONTACT
    {
        public int inbox_id { get; set; } = 2;
        public string name { get; set; }
        public string phone_number { get; set; }
        public Custom_Attributes custom_attributes { get; set; }
    }

}
