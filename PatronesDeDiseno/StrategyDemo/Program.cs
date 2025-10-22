using System;

namespace StrategyDemo
{
    public interface IPagoStrategy
    {
        void Pagar(decimal monto);
    }

    // Estrategias: Pago con tarjeta y pago en efectivo
    public class PagoConTarjeta : IPagoStrategy
    {
        public void Pagar(decimal monto) {
            Console.WriteLine($"Pagando {monto:C} con tarjeta.");
        }
    }
    public class PagoConEfectivo : IPagoStrategy
    {
        public void Pagar(decimal monto){
            Console.WriteLine($"Pagando {monto:C} en efectivo.");
        }
    }

    // Contexto
    public class ProcesadorDePagos
    {
        private IPagoStrategy _strategy;

        public ProcesadorDePagos(IPagoStrategy strategy)
        {
            _strategy = strategy;
        }
        public void SetStrategy(IPagoStrategy strategy)
        {
            _strategy = strategy;
        }
        public void EjecutarPago(decimal monto)
        {
            _strategy.Pagar(monto);
        }
    }

    class Program
    {
        static void Main()
        {
            var procesador = new ProcesadorDePagos(new PagoConTarjeta());
            procesador.EjecutarPago(1000);

            procesador.SetStrategy(new PagoConEfectivo());
            procesador.EjecutarPago(500);
        }
    }
}
