using System.Text;

namespace MemoryStringInfo
{
    class MemoryStringInfo
    {
        public static void Main()
        {
            MemoryStream ms1 = new MemoryStream();
            InformacionMS(ms1);
            Console.WriteLine("Ingrese un string");
            string cadena = Console.ReadLine();
            byte[] bufferCadena;

            bufferCadena = Encoding.UTF8.GetBytes(cadena);
            ms1.Write(bufferCadena, 0, bufferCadena.Length);
            InformacionMS(ms1);

            // Agregar una segunda cadena
            string texto1 = "alberto";
            ms1.Seek(1, SeekOrigin.Current + 1);
            ms1.Write(Encoding.UTF8.GetBytes(texto1), 0, texto1.Length);
            InformacionMS(ms1);

            // usando Seek
            ms1.Seek(1, SeekOrigin.Current + 1);
            string texto2 = "1";
            ms1.Write(Encoding.UTF8.GetBytes(texto2), 0, texto2.Length);
            InformacionMS(ms1);

            // Leer
            byte[] bufferLectura = new byte[100];
            ms1.Seek(0, SeekOrigin.Begin);
            int bytesLeidos = ms1.Read(bufferLectura, 0, (int)ms1.Length);

            string cadenaLeida = Encoding.UTF8.GetString(bufferLectura);
            Console.WriteLine($"\n\nBytes leidos: {bytesLeidos}, Cadena leida: '{cadenaLeida}'");

            // Cerrar flujo
            ms1.Close();
            InformacionMS(ms1);

            void InformacionMS(MemoryStream msTest)
            {
                Console.WriteLine("\nInformacion:");
                Console.WriteLine("Capacidad: {0}", msTest.Capacity);
                Console.WriteLine("Longitud: {0}", msTest.Length);
                Console.WriteLine("Posicion: {0}", msTest.Position);
            }
        }
    }
}
