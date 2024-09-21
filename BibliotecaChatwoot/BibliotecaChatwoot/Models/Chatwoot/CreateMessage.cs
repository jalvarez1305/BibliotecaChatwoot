using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.Models.Chatwoot
{
    public class CreateMessage
    {
        public string content { get; set; }
        public string message_type { get; set; } = "outgoing";
        public bool @private { get; set; } = false;
    }
}
