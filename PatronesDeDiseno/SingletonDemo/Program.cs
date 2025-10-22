using System;

// Implementacion de una clase logger global usando el patron Singleton
namespace SingletonDemo
{
    public class Logger
    {
        private static Logger _instancia;

        public static Logger Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Logger();
                }
                return _instancia;
            }
        }

        public void Log(string mensaje)
        {
            Console.WriteLine($"[{DateTime.Now}] {mensaje}");
        }
    }

    class Program
    {
        static void Main()
        {
            var log1 = Logger.Instancia;
            var log2 = Logger.Instancia;

            log1.Log("Inicio del programa");
            log2.Log("Esta es la misma instancia");

            Console.WriteLine(ReferenceEquals(log1, log2)
                ? "Es la misma instancia"
                : "Son diferentes instancias");
        }
    }
}
