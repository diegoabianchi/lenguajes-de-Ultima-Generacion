using System;

namespace DecoratorDemo
{
    // Componente (interfaz)
    public interface IBebida
    {
        string Descripcion { get; }
        double Costo();
    }

    // Componente concreto
    public class Cafe : IBebida
    {
        public string Descripcion => "Café";
        public double Costo() => 100;
    }

    // Decorador base
    public abstract class BebidaDecorator : IBebida
    {
        protected IBebida _bebida;
        public BebidaDecorator(IBebida bebida){
            _bebida = bebida;
        }
        public abstract string Descripcion { get; }
        public abstract double Costo();
    }

    // Decoradores concretos: con leche y con azúcar
    public class ConLeche : BebidaDecorator
    {
        public ConLeche(IBebida bebida) : base(bebida) { }
        public override string Descripcion => _bebida.Descripcion + " con leche";
        public override double Costo() => _bebida.Costo() + 30;
    }
    public class ConAzucar : BebidaDecorator
    {
        public ConAzucar(IBebida bebida) : base(bebida) { }
        public override string Descripcion => _bebida.Descripcion + " con azúcar";
        public override double Costo() => _bebida.Costo() + 10;
    }

    class Program
    {
        static void Main()
        {
            IBebida cafe = new Cafe();
            cafe = new ConLeche(cafe);
            cafe = new ConAzucar(cafe);

            Console.WriteLine($"{cafe.Descripcion} cuesta {cafe.Costo()} pesos.");
        }
    }
}
