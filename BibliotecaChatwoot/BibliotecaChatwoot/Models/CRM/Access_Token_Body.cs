using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.Models.CRM
{
    public class Access_Token_Body
    {
        public string grant_type { get; } = "password";
        public string client_id { get; } = "319147c2-dfff-d567-6672-65fc49870cfc";
        public string client_secret { get; } = "c5fTGBJBOEOO6MfuDgZqRKzYfZR5MoKdSNIs0jlEzI4=";
        public string username { get; } = "admin";
        public string password { get; } = "admin#0309";
    }
}
