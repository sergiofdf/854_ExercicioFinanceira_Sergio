using _854_ExercicioFinanceira_Sergio;

ControlaSistema();

void ControlaSistema()
{
    int escolhaUsuario = IniciaPrograma();
    Console.Clear();
    Contrato contrato = CriaContrato(escolhaUsuario);
    contrato.ExibirInfo();
    EncerraPrograma();
}

int IniciaPrograma()
{
    Console.WriteLine(@"Sistema de Gestão de Contratos de Financiamento

Gostaria de realizar o cadastro de um contrato de:
1 - Pessoa física
2 - Pessoa Jurídica
");
    int tipoCadastro = Validacoes.ConsoleIntIntervalo(1, 2);
    return tipoCadastro;
}

Contrato CriaContrato(int tipoCadastro)
{
    Console.WriteLine("Qual o nome do contratante?");
    string nomeContratante = Validacoes.ConsoleSemVazio();
    Console.Clear();
    Console.WriteLine("Qual o valor do financiamento?");
    decimal valorContrato = Validacoes.ConsoleDecimalPositivo();
    Console.Clear();
    Console.WriteLine("Qual o prazo do financiamento em meses?");
    int prazoContrato = Validacoes.ConsoleIntIntervalo(1, 240);
    Console.Clear();

    if (tipoCadastro == 1)
    {
        Console.WriteLine("Qual o CPF do contratante?");
        string cpfDigitado = Validacoes.ConsoleSemVazio();
        Console.Clear();
        while (!Validacoes.CpfValido(cpfDigitado))
        {
            cpfDigitado = Validacoes.ConsoleSemVazio();
            Console.Clear();
        }
        Console.WriteLine("Qual a data de nascimento do contratante?");
        DateTime dataNascimento = Validacoes.ConsoleData();
        Console.Clear();
        ContratoPessoaFisica contratoPf = new(nomeContratante, valorContrato, prazoContrato, cpfDigitado, dataNascimento);

        return contratoPf;
    }
    else
    {
        Console.WriteLine("Qual o CNPJ do contratante?");
        string cnpjDigitado = Validacoes.ConsoleSemVazio();
        Console.Clear();
        while (!Validacoes.CnpjValido(cnpjDigitado))
        {
            cnpjDigitado = Validacoes.ConsoleSemVazio();
            Console.Clear();
        }
        Console.WriteLine("Qual o número de inscrição estadual do contratante?");
        string numeroInscricaoDigitado = Validacoes.ConsoleSemVazio();
        Console.Clear();
        while (!Validacoes.InscricaoValida(numeroInscricaoDigitado))
        {
            numeroInscricaoDigitado = Validacoes.ConsoleSemVazio();
            Console.Clear();
        }
        ContratoPessoaJuridica contratoPj = new(nomeContratante, valorContrato, prazoContrato, cnpjDigitado, numeroInscricaoDigitado);
        return contratoPj;
    }
}

void EncerraPrograma()
{
    Console.WriteLine(@"

Deseja Encerrar o programa?
1 - Sim
2 - Não");
    int decisaoEncerramento = Validacoes.ConsoleIntIntervalo(1, 2);
    if (decisaoEncerramento == 1)
    {
        return;
    }
    else
    {
        Console.Clear();
        ControlaSistema();
    }
}

