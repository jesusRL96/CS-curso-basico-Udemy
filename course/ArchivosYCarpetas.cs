using System.Text;

namespace ArchivosYCarpetas
{
    class ArchivosYCarpetas()
    {
        static public void Main()
        {
            // PruebasLecturaArchivos();
            // PruebasLecturaStream();
            // PruebasUsing();
            PruebasMoverArchivos();
        }

        static void PruebasLecturaArchivos()
        {
            // Pruebas File
            var fs = new FileStream("file_test.txt", FileMode.Open);
            var buffer = new byte[1024];
            fs.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
            // Crear objeto FileStream (crear archivo)
            var bufferAppend = Encoding.UTF8.GetBytes("=Texto extra=");
            fs.Write(bufferAppend, 0, bufferAppend.Length);
            fs.Close();

            var fsC = File.Create("file_test_created.txt");

            fsC.Close();

            // Escribir archivo
            File.WriteAllText("file_test_created.txt", "texto escrito");

            // Append texto
            File.AppendAllText("file_test_created.txt", " ++Texto con append++");
        }

        static void PruebasLecturaStream()
        {
            // Usando streamwriter
            var sw = new StreamWriter("file_test_stream_writer.txt");
            sw.WriteLine("Texto de prueba");
            sw.Write("Otro texto");
            sw.Close();
            // con append
            var sw1 = new StreamWriter("file_test_stream_writer.txt", true);
            sw1.WriteLine("Texto anexado");
            sw1.Close();

            // Usando streamreader
            var sr = new StreamReader("archivo_leer.txt");
            string textoArchivo = sr.ReadLine();
            Console.Write(textoArchivo);
        }

        static void PruebasUsing()
        {
            // Pruebas con instruccion using para trabajar con archivos
            string textoArchivo;
            using (var sr = new StreamReader("archivo_leer.txt"))
            {
                textoArchivo = sr.ReadLine();
            }
            Console.Write(textoArchivo);
        }

        //+++++++++++++++++++++ DIRECTORIOS/ ARCHIVOS ++++++++++++++++++
        static void PruebasMoverArchivos()
        {
            // Validar si un directorio existe
            var directorio = "carpeta_destino";
            if (!Directory.Exists(directorio))
            {
                Console.WriteLine("la carpeta no existe");
                DirectoryInfo info = Directory.CreateDirectory(directorio);
                Console.WriteLine("carpeta creada");
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.CreationTime);
            }
            else
            {
                Console.WriteLine("la carpeta existe");
            }
            // validar archivo existe
            string archivo = "archivo_leer.txt";
            bool existe = ValidarArchivo(archivo);
            if (File.Exists($"./carpeta_destino/{archivo}"))
            {
                // Delete.Copy(origen)
                File.Delete($"./carpeta_destino/{archivo}");
            }
            // copiar archivo
            if (existe)
            {
                // File.Copy(origen, destino)
                File.Copy(archivo, $"./carpeta_destino/{archivo}");
                // Delete.Copy(origen)
                File.Delete(archivo);
                Console.WriteLine("archivo eliminado");
                // validar archivo NO existe
                existe = ValidarArchivo(archivo);
                Console.ReadKey();
                // Move.Copy(origen, destino)
                File.Move($"./carpeta_destino/{archivo}", archivo);
            }
            // Eliminar directorio
            Directory.Delete(directorio);
            Console.WriteLine("directorio eliminado");

            // Listar archivos en directorio
            Console.WriteLine("ARCHIVOS EN CARPETA");
            var nombresArchivos = Directory.GetFiles("./course");
            // Console.WriteLine(string.Join(", ", nombresArchivos));
            foreach (string file in nombresArchivos)
            {
                Console.WriteLine("{0} ({1})", Path.GetFileName(file), Path.GetExtension(file));
            }
            // Listar carpetas
            Console.WriteLine("CARPETAS EN CARPETA");
            var nombresDirectories = Directory.GetDirectories("./");
            foreach (string directory in nombresDirectories)
            {
                Console.WriteLine(
                    "{0}: {1}",
                    Path.GetDirectoryName(directory),
                    Path.GetFileName(directory)
                );
            }
            // Listar archivos y carpetas
            Console.WriteLine("ARCHIVOS Y CARPETAS EN CARPETA");
            var entries = Directory.GetFileSystemEntries("./");
            foreach (string directory in entries)
            {
                Console.WriteLine(
                    "{0}: {1}",
                    Path.GetDirectoryName(directory),
                    Path.GetFileName(directory)
                );
            }

            static bool ValidarArchivo(string archivoValidar)
            {
                bool existe = File.Exists(archivoValidar);
                if (existe)
                {
                    Console.WriteLine($"El archivo {archivoValidar} si existe");
                }
                else
                {
                    Console.WriteLine($"El archivo {archivoValidar} NO existe");
                }
                return existe;
            }
        }
    }
}
