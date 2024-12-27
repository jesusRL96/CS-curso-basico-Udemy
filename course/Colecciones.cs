namespace Colecciones
{
    class Ejercicio1
    {
        static public void Main()
        {
            List<string> estudiantes = new List<string>();

            int opcion;

            do
            {
                Console.WriteLine("Elige una opcion");
                Console.WriteLine("1. Agregar usuario");
                Console.WriteLine("2. Eliminar ultimo usuario");
                Console.WriteLine("3. Eliminar usuario por numero");
                Console.WriteLine("4. Eliminar usuario por nombre");
                Console.WriteLine("5. Mostrar usuarios");
                Console.WriteLine("6. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        estudiantes.Add(GetUserInput("Indique el nombre:\n"));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("estudiante removido");
                        estudiantes.RemoveAt(estudiantes.Count - 1);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Eliminar el usuario numero:");
                        int i = 0;
                        estudiantes.ForEach(element =>
                        {
                            Console.WriteLine("{0}. {1}", i + 1, element);
                            i++;
                        });
                        int indice = Convert.ToInt32(Console.ReadKey());
                        estudiantes.RemoveAt(indice - 1);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        estudiantes.ForEach(i => Console.WriteLine(i));
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.Clear();
            } while (opcion != 6);

            static string GetUserInput(string mensaje)
            {
                Console.WriteLine(mensaje);
                return Console.ReadLine();
            }
        }
    }
}
