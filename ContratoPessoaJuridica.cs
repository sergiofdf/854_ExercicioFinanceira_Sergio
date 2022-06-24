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
            string inscricaoEstadual2 = inscricaoEstadual.Replace(".", "");
            InscricaoEstadual = inscricaoEstadual2;
            Valor = valor;
            Prazo = prazo;
            string cnpj2 = cnpj.Replace(".", "");
            string cnpj3 = cnpj2.Replace("-", "");
            string cnpj4 = cnpj3.Replace("/", "");
            Cnpj = cnpj4;
        }
        public override decimal CalcularPrestação()
        {
            return base.CalcularPrestação() + 3;
        }
        public override void ExibirInfo()
        {
            Console.WriteLine("\n--- Dados do Contrato ---");
            Console.WriteLine($"CNPJ do Contrante: {Cnpj}");
            Console.WriteLine($"Inscrição Estadual: {InscricaoEstadual}");
            base.ExibirInfo();
        }
    }
}
