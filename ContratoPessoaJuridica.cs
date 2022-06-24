namespace _854_ExercicioFinanceira_Sergio
{
    public class ContratoPessoaJuridica : Contrato
    {
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }

        public ContratoPessoaJuridica(string contratante, decimal valor, int prazo, string cnpj, string inscricaoEstadual)
        {
            IdContrato = Guid.NewGuid();
            Contratante = contratante;
            InscricaoEstadual = inscricaoEstadual;
            Valor = valor;
            Prazo = prazo;
            Cnpj = cnpj;
        }
        public override decimal CalcularPrestação()
        {
            return base.CalcularPrestação() + 3;
        }
        public override void ExibirInfo()
        {
            Console.WriteLine("--- Dados do Contrato ---");
            Console.WriteLine($"CNPJ do Contrante: {Cnpj}");
            Console.WriteLine($"Inscrição Estadual: {InscricaoEstadual}");
            base.ExibirInfo();
        }
    }
}
