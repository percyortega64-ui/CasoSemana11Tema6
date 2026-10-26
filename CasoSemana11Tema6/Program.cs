using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSemana11Tema6
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombreCursos = { "Matematica", "Programación", "Fisica", "Base de datos" };
        static string[] estudiante = new string[max_estudiantes];
        static double[,] matrizNotas = new double[max_estudiantes, max_cursos];
        static int total_estudiantes = 0;
        static string rutaArchivo = "notas_curso.txt";

        public static void RegistrarEstudiante()
        {
            Console.WriteLine("Registro De Estudiantes");
            if (total_estudiantes >= max_estudiantes)
            {
                Console.WriteLine("Se ha alcanzado la capacidad maxima de estudiantes");
                return;
            }
            string nombre = Validador.LeerTexto("Ingrese  los nombres y apellidos del estudiante: ").ToUpper();
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas de 0 a 20: ");
            for (int i = 0; i < max_cursos; i++)
            {
                matrizNotas[total_estudiantes, i] = Validador.LeerDecimal($"Ingresar nota de {nombreCursos[i]}: ");
            }
            total_estudiantes += 1;
            Console.WriteLine("Estudiante registrado");
        }
        public static void guardarArchivo()
        {
            Console.WriteLine("Guardar registros en archivo");
            if (total_estudiantes == 0)
            {
                Console.WriteLine("Sin Registros a guardar");
                return;
            }
            using (StreamWriter escritor = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < total_estudiantes; i++)
                {
                    String Linea = estudiante[i];
                    for (int j = 0; j < max_cursos; j++)
                    {
                        Linea += "," + matrizNotas[i, j];
                        //Linea += $",{matrizNotas[i, j]}";

                    }
                    escritor.WriteLine(Linea);
                }
            }
            Console.WriteLine("Registros guardados");

        }
        public static void CargarRegistros()
        {
            Console.WriteLine("Cargar Registros Desde Archivo");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("No existe el archivo");
                return;
            }
            total_estudiantes = 0;
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null && total_estudiantes < max_estudiantes)

                {
                    string[] partes = linea.Split(',');
                    if (partes.Length > max_cursos + 1)
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for (int i = 0; i < max_cursos; i++)
                        {
                            matrizNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                        }
                        total_estudiantes++;
                    }
                }
            }
            Console.WriteLine("Se cargaron los registros del archivo");
        }
        public static void mostrarRegistros()
        {
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\t\tRegistro General De Notas Por Curso");
            Console.WriteLine(new string('=', 100));
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No existe Registros");
                return;
            }
            Console.Write($"{"estudiante",-25}|");
            for (int i = 0;i < max_cursos;i++)
            {
                Console.Write($"{nombreCursos[i],-12}|");
            }
            Console.WriteLine("promedio");
            Console.WriteLine(new string ('-', 100));
            for(int i = 0;i<total_estudiantes ; i++)
            {
                Console.Write($"{estudiante[i],-25}|");
                double suma = 0;
                for (int j = 0;j < max_cursos;j++)
                {
                    Console.Write($"{matrizNotas[i,j],-12:F1}!");
                    suma += matrizNotas[i, j];
                }
                double promedio=suma/max_cursos;
                string estado = promedio >= 12 ? "aprobado" : "desaprobado";
                Console.WriteLine($"{promedio:F2} ({estado})");

            }
        }
            static void Main(string[] args)
            {
              int opc= 0;
            while(opc != 5)
            {
                Console.Clear();
                Console.WriteLine("[1]Registrar Estudiante");
                Console.WriteLine("[2]Guardar en archivos");
                Console.WriteLine("[3]Cargar Registros Del Archivo");
                Console.WriteLine("[4]Mostrar Registros");
                Console.WriteLine("[5]Salir");
                opc = Validador.LeerEntero("Seleccionar opcion [1-5]:");
                switch (opc)
                {
                    case 1:
                        RegistrarEstudiante() ; break;
                    case 2:
                        guardarArchivo() ; break;
                    case 3:
                        CargarRegistros() ; break;
                    case 4:
                        mostrarRegistros() ; break;
                    case 5:
                        Console.WriteLine("Muchos exitos para el nuevo semestre"); break;
                }
                Console.ReadKey();
            }
           }
        }
    }

