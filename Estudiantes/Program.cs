using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  Tarea de Cristhian Fonseca Hernandez

namespace Estudiantes
{
    class Program
    {
        public static int contador = 0; //  Para llevar un conteo de los estudiantes ingresados
        public static string[] estudiantes = new string[100]; //    Arreglo para almacenar los nombres de los estudiantes
        public static float[] notas = new float[100]; //   Arreglo para almacenar las notas de los estudiantes

        static void Main(string[] args)
        {
            byte opcion = 0;
            do // se despliega Menu, el programa se ejecuta dentro de un do-while que permite mantenerlo en funcionamiento
              //  durante el ciclo
            {
                Console.WriteLine("Menú\n");
                Console.WriteLine("1. Agregar Estudiantes");
                Console.WriteLine("2. Buscar Estudiante");
                Console.WriteLine("3. Asignar calificación");
                Console.WriteLine("4. Imprimir Estudiantes");
                Console.WriteLine("5. Salir");
                Console.Write("---------------------------");
                Console.Write("\nDigite una opción: ");
                opcion = byte.Parse(Console.ReadLine());
                Console.Write("---------------------------\n");

                switch (opcion)
                {
                    case 1:
                        AgregarEstudiante.Agregar();
                        break;
                    case 2:
                        BuscarEstudiante.Buscar();
                        break;
                    case 3:
                        AsignarCalificacion.Asignar();
                        break;
                    case 4:
                        ImprimirInformacion.Imprimir();
                        break;
                }
            } while (opcion != 5);
        }
    }

    class AgregarEstudiante
    {
        public static void Agregar()
        {
            Console.Write("Digite el nombre: ");
            string nombre = Console.ReadLine();

            int indice = -1; // Variable que es modificada en caso de encontrar al estudiante
                             // (-1 ya que permite recorrer el arreglo desde 0 en adelante, y en caso de no existir -1 no seria una posicion)
            for (int i = 0; i < Program.contador; i++)
            {
                if (Program.estudiantes[i] == nombre)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                Program.estudiantes[Program.contador] = nombre;
                Console.Write("Ingrese calificación: ");
                float calificacion = float.Parse(Console.ReadLine());
                Program.notas[Program.contador] = calificacion;
                Program.contador++;
                Console.Write("---------------------------");
                Console.Write("\n¿Desea agregar otro estudiante? (s/n): ");
                string respuesta = Console.ReadLine(); 
                Console.Write("---------------------------\n");
                if (respuesta == "s")
                {
                    Agregar(); //   tras seleccionar "s", se vuelve a llamar al metodo Agregar
                }
            }
            else // En caso de encontrarse, despliega el siguiente mensaje
            {
                Console.Write("---------------------------");
                Console.WriteLine("\nEstudiante ya existe");
                Console.Write("---------------------------\n");
            }
        }
    }

    class BuscarEstudiante
    {
        public static void Buscar()
        {
            Console.Write("Ingrese nombre del estudiante: ");
            string nombre = Console.ReadLine();

            int indice = -1;// Variable que es modificada en caso de encontrar al estudiante
                            // (-1 ya que permite recorrer el arreglo desde 0 en adelante, y en caso de no existir -1 no seria una posicion)
            for (int i = 0; i < Program.contador; i++)
            {
                if (Program.estudiantes[i] == nombre)
                {
                    indice = i; //  Se le asigna el valor de i que refleja la posicion en la que fue encontrado el estudiante
                    break;
                }
            }
            if (indice != -1)
            {
                Console.Write("---------------------------");
                Console.WriteLine("\nEstudiante encontrado en la posicion " + indice);
                Console.Write("---------------------------");
            }
            else // En caso de no encontrarse, despliega el siguiente mensaje
            {
                Console.Write("---------------------------");
                Console.WriteLine("\nEstudiante no encontrado");
                Console.Write("---------------------------\n");
            }
        }
    }
    class AsignarCalificacion
    {
        public static void Asignar()
        {
            Console.Write("Ingrese nombre del estudiante: ");
            string nombre = Console.ReadLine();

            int indice = -1;// Variable que es modificada en caso de encontrar al estudiante
                            // (-1 ya que permite recorrer el arreglo desde 0 en adelante, y en caso de no existir -1 no seria una posicion)
            for (int i = 0; i < Program.contador; i++)
            {
                if (Program.estudiantes[i] == nombre)
                {
                    indice = i; //  Se le asigna el valor de i que refleja la posicion en la que fue encontrado el estudiante
                    break;
                }
            }

            if (indice != -1) //    Si se encuentra el estudiante, entonces se permite modificar el arreglo en la posicion de i (indice = i), 
                              //    la cual coincide con el estudiante en dicha posicion
            {
                Console.Write("Ingrese nueva calificación: ");
                float calificacion = float.Parse(Console.ReadLine());
                Program.notas[indice] = calificacion; //    Se modifica el valor de la calificacion 
                Console.Write("---------------------------");
            }
            else // En caso de no encontrarse, despliega el siguiente mensaje
            {
                Console.Write("---------------------------");
                Console.WriteLine("\nEstudiante no encontrado");
                Console.Write("---------------------------\n");
            }
        }
    }

    class ImprimirInformacion
    {
        public static void Imprimir()
        {
            //  se recorre estudiantes[] y notas[] mediante un ciclo for
            Console.WriteLine("\nInformación de estudiantes:  \n");
            for (int i = 0; i < Program.contador; i++)
            {
                Console.WriteLine("Nombre: " + Program.estudiantes[i] + ", Calificación: " + Program.notas[i]);
            }
            Console.Write("\n---------------------------");
        }
    }
}
