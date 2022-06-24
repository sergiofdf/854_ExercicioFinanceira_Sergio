namespace _854_ExercicioFinanceira_Sergio
{
    public class ContratoPessoaFisica : Contrato
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public ContratoPessoaFisica(string contratante, decimal valor, int prazo, string cpf, DateTime dataNascimento)
        {
            IdContrato = Guid.NewGuid();
            Contratante = contratante;
            Valor = valor;
            Prazo = prazo;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
        public override decimal CalcularPrestação()
        {
            int idade = CalcularIdade();
            int adicional = CalculaAdicional(idade);
            return base.CalcularPrestação() + adicional;
        }
        public int CalcularIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
        public int CalculaAdicional(int idade)
        {
            int adicional = 0;
            if (idade <= 30)
            {
                adicional = 1;
            }
            else if (idade <= 40)
            {
                adicional = 2;
            }
            else if (idade <= 50)
            {
                adicional = 3;
            }
            else if (idade > 50)
            {
                adicional = 4;
            }
            return adicional;
        }
        public override void ExibirInfo()
        {
            Console.WriteLine("--- Dados do Contrato ---");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Idade Contratante: {CalcularIdade()}");
            base.ExibirInfo();
        }
    }
}
