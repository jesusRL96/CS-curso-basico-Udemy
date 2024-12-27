namespace Colecciones
{
    class EjercicioGastos
    {
        static public void Main()
        {
            Stack<Dictionary<string, object>> gastos = new Stack<Dictionary<string, object>>();

            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Elige una opcion");
                Console.WriteLine("1. Ingresar gasto");
                Console.WriteLine("2. Mostrar gastos");
                Console.WriteLine("3. Sumar gastos hechos");
                Console.WriteLine("4. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        var nombreGasto = GetUserInput("Ingrese el nuevo gasto:\n");
                        var montoGasto = Convert.ToDouble(
                            GetUserInput("Ingrese el monto del gasto:\n")
                        );
                        var nuevoGasto = new Dictionary<string, object>();
                        nuevoGasto.Add("nombre", nombreGasto);
                        nuevoGasto.Add("monto", montoGasto);
                        gastos.Push(nuevoGasto);
                        break;
                    case 2:
                        MostarGastos(gastos);
                        break;
                    case 3:
                        MostarGastos(gastos);
                        double total = 0;
                        foreach (var gasto in gastos)
                        {
                            total += (double)gasto["monto"];
                        }
                        Console.WriteLine("Total: {0}", total);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 4);

            static string GetUserInput(string mensaje)
            {
                Console.WriteLine(mensaje);
                return Console.ReadLine();
            }

            static void MostarGastos(Stack<Dictionary<string, object>> gastos)
            {
                int i = 0;
                Console.WriteLine("Gastos:");
                foreach (var gasto in gastos)
                {
                    Console.WriteLine("{0}. {1}: ${2}", i + 1, gasto["nombre"], gasto["monto"]);
                    i++;
                }
            }
        }
    }
}
