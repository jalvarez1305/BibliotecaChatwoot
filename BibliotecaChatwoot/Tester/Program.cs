using BibliotecaChatwoot.Models.Chatwoot;
using BibliotecaChatwoot.Services.Chatwoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BibliotecaChatwoot.Services.Twilio;
using BibliotecaChatwoot.Services.AWS;
using System.IO;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            S3Manager s3 = new S3Manager();
            var datos = File.ReadAllBytes(@"C:\Users\jalva\Downloads\1314122799669-12216213223-boleto.pdf");
            await s3.UploadObject("test", datos);
        }
    }
}
