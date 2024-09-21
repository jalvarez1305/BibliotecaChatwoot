using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models.Airtable
{
    public class CM_Videos_Boletos
    {
        public int ID { get; set; }
        public string UUID { get; set; }
        public string UUID_Referencia { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;
        public int Ticket { get; set; }
    }
}
