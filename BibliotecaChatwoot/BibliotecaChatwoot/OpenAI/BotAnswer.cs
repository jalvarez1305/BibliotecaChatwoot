using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasCrediMotos.OpenAI
{
    public class BotAnswer
    {
        public string Answer { get; set; }
        public bool canAnswer { get; set; }
        public bool isDone { get; set; }
    }
}
