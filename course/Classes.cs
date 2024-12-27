// See https://aka.ms/new-console-template for more information
namespace test_console.Classes
{
    class Classes()
    {
        static public void Main()
        {
            CuentaBancaria miCuenta = new CuentaBancaria("nombre", "apellidos");
            miCuenta.Nombre = "Nuevo nombre";
            // miCuenta.Apellidos = "Nuevo Apellido";
            // Console.WriteLine(miCuenta.ToString());
            // miCuenta.ConsultarSaldo();
            // miCuenta.Depositar(1234, 500);
            // miCuenta.AsignarNIP(1234);
            // miCuenta.Depositar(12345, 500);
            // miCuenta.Depositar(1234, 500);
            // miCuenta.ConsultarSaldo();
            // miCuenta.Retirar(1234, 600);
            // miCuenta.Retirar(1234, 450);
            // miCuenta.ConsultarSaldo();

            bool exit = false;
            do
            {
                Console.WriteLine("Seleccione una opcion:");
                Console.WriteLine("1. Consultar informacion de la cuenta");
                Console.WriteLine("2. Consultar saldo");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Retirar");
                Console.WriteLine("5. Salir");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(miCuenta.ToString());
                        break;
                    case 2:
                        miCuenta.ConsultarSaldo();
                        break;
                    default:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }

    class CuentaBancaria
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string UniqueId { get; private set; }

        public string? Direccion { get; set; }

        public string? RFC { get; set; }
        private int? NIP { get; set; }

        public double Saldo { get; set; } = 0;

        public CuentaBancaria(string nombre, string apellidos, string? direccion = null)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.UniqueId = Guid.NewGuid().ToString();
            this.Direccion = direccion;
        }

        // Metodos
        public override string ToString()
        {
            return $"Nombre: {this.Nombre} \nApellidos: {this.Apellidos}"
                + $"\nRFC: {this.RFC} \tDireccion: {Direccion}"
                + $"\nSALDO: ${this.Saldo}";
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"El saldo de tu cuenta es: ${this.Saldo}");
        }

        public void AsignarNIP(int nip)
        {
            this.NIP = nip;
        }

        private bool ValidarNIP(int nip)
        {
            if (this.NIP == null)
            {
                Console.WriteLine("Usted no tiene un NIP asignado");
            }
            else if (nip == this.NIP)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"El NIP {nip} es incorecto");
            }
            return false;
        }

        public double Depositar(int nip, double deposito)
        {
            if (this.ValidarNIP(nip))
            {
                this.Saldo += deposito;
            }
            return this.Saldo;
        }

        public double Retirar(int nip, double montoRetiro)
        {
            if (this.Saldo < montoRetiro)
            {
                Console.WriteLine($"El monto de retiro es mayo al saldo {this.Saldo}");
                return this.Saldo;
            }
            else if (this.ValidarNIP(nip))
            {
                this.Saldo -= montoRetiro;
            }
            return this.Saldo;
        }
    }
}
