using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot.Models
{
    public class Templates
    {
        public string sorteo_240430 { get; set; } =
@"Ey, {{1}}! 🏍️ Casi te ganas tu moto, ¡qué emoción! 😁 Ahora manda tu video respondiendo estas preguntillas:

1️⃣ ¿Cuál moto te gustaría y para qué la quieres?
2️⃣ ¿Cuánto ganas y en qué trabajas?
3️⃣ ¡Cuéntanos una historia en moto!

¡Esperamos tu video, campeón! 📹💨";
        //public string sorteo_240429 { get; set; } =
        //    @"Bienvenido a credi motos {{1}} , ya casi estamos lavando tu moto. Estas listo para recibirla?";

        public string segundo_boleto { get; } = "🎉 ¡Felicidades! 🎉 {{1}} se registró y te acabas de ganar un nuevo boleto para la moto. 🏍️ Es este: {{2}}. Ahora tienes más oportunidades de ganártela. ¡Buena suerte y mucha felicidad! 🍀😃";
    }
}
