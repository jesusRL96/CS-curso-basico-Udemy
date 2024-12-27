namespace GenerarContrasenia
{
    class GenerarContrasenia
    {
        public static void Main()
        {
            Console.WriteLine("Ingrese el numero de caracteres que quiere en su contraseña min(4)");
            int passLength = Convert.ToInt32(Console.ReadLine());
            string password = GeneratePassword(passLength);

            Console.WriteLine(password);

            string GeneratePassword(int passLength)
            {
                char[] especiales = ['#', '@', '%', '^', '&'];
                char[] letras = ['a', 'v', 'c', 'd', 'e'];
                char[] letrasMayusculas = ['A', 'V', 'C', 'D', 'E'];
                var dataPassword = new Dictionary<string, char[]>()
                {
                    ["especiales"] = especiales,
                    ["letras"] = letras,
                    ["letrasMayusculas"] = letrasMayusculas,
                    ["numeros"] = ['1', '2', '3', '4'],
                };

                // Definir cantidad por tipo de caracter
                var charTypeLength = new Dictionary<string, int>();
                foreach (string key in dataPassword.Keys)
                {
                    charTypeLength[key] = (int)Math.Floor(passLength * 0.25);
                }
                Console.WriteLine(string.Join(", ", charTypeLength));

                char[] passwordChar = new char[passLength];
                int counter = 0;
                Random randomG = new Random();
                foreach (KeyValuePair<string, int> charLength in charTypeLength)
                {
                    for (int j = 0; j < charLength.Value; j++)
                    {
                        int index = randomG.Next(dataPassword[charLength.Key].Length);
                        passwordChar[counter] = dataPassword[charLength.Key][index];
                        counter++;
                    }
                }
                string password = string.Join("", passwordChar);
                Console.WriteLine("password: {0}", password);

                return password;
            }
        }
    }
}
