using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSemana11Tema6
{
    internal class Validador
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 1 || valor > 5)
                    {
                        Console.WriteLine("Error: El valor es entre[1,5]");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error:el valor debe ser numerico entero");
            }
        }
        public static double LeerDecimal(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(),out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("Error: El valor es entre[0,20]");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error:el valor debe ser numerico decimal ");
            }
        }
        public static string LeerTexto(string mensaje) 
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(texto))
                    return texto;
                Console.WriteLine("Error:este campo no puede ser vacio");

            }
        }

    }
}


