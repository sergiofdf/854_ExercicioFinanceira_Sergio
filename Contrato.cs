namespace _854_ExercicioFinanceira_Sergio
{
    public class Contrato
    {
        public Guid IdContrato { get; set; }
        public string Contratante { get; set; }
        public decimal Valor { get; set; }
        public int Prazo { get; set; }

        public virtual decimal CalcularPrestação()
        {
            return Valor / Prazo;
        }
        public virtual void ExibirInfo()
        {
            string unidadePrazo = Prazo > 1 ? "meses" : "mês";
            Console.WriteLine($"Número do contrato: {IdContrato}");
            Console.WriteLine($"Contratante: {Contratante}");
            Console.WriteLine($"Valor Total: R${Valor.ToString("F")}");
            Console.WriteLine($"Prazo: {Prazo} {unidadePrazo}");
            Console.WriteLine($"Prestação: R${ CalcularPrestação().ToString("F")}\n");
        }
    }
}
