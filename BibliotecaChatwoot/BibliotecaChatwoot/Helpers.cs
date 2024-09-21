using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaChatwoot
{
    internal class Helpers
    {
        public bool AreAllDigits(string input)
        {
            foreach (char c in input)
            {
                // Intentar convertir el carácter a un número
                if (!int.TryParse(c.ToString(), out _))
                {
                    // Si el carácter no se puede convertir a un número, retornar falso
                    return false;
                }
            }
            // Si todos los caracteres se pueden convertir a números, retornar verdadero
            return true;
        }
    }
}
