using _854_ExercicioFinanceira_Sergio;

List<ContratoPessoaFisica> contratosPf = new();
List<ContratoPessoaJuridica> contratosPj = new();
ExecutaPrograma();

void ExecutaPrograma()
{
    int escolhaUsuario = IniciaPrograma();
    Console.Clear();
    if (escolhaUsuario == 1)
    {
        ContratoPessoaFisica contratoPf = CriaContratoPf();
        contratosPf.Add(contratoPf);
        contratoPf.ExibirInfo();
    }
    else if (escolhaUsuario == 2)
    {
        ContratoPessoaJuridica contratoPj = CriaContratoPj();
        contratosPj.Add(contratoPj);
        contratoPj.ExibirInfo();
    }
    else
    {
        int tipoConsulta = EscolhaTipoConsulta();
        Console.Clear();
        if (tipoConsulta == 1)
        {
            Console.WriteLine("Qual o nome que deseja buscar?");
            string nome = Validacoes.ConsoleSemVazio();
            ConsultaPorNome(nome);
        }
        else if (tipoConsulta == 2)
        {
            Console.WriteLine("Qual o CPF que deseja buscar?");
            string cpf = Validacoes.ConsoleSemVazio();
            string cpf2 = cpf.Replace(".", "");
            string cpf3 = cpf2.Replace("-", "");
            ConsultaPorCpf(cpf3);
        }
        else if (tipoConsulta == 3)
        {
            Console.WriteLine("Qual o CNPJ que deseja buscar?");
            string cnpj = Validacoes.ConsoleSemVazio();
            string cnpj2 = cnpj.Replace(".", "");
            string cnpj3 = cnpj2.Replace("-", "");
            string cnpj4 = cnpj3.Replace("/", "");
            ConsultaPorCnpj(cnpj4);
        }
        else if (tipoConsulta == 4)
        {
            Console.WriteLine("Qual o número do contrato que deseja buscar?");
            string numero = Validacoes.ConsoleSemVazio();
            ConsultaPorNumero(numero);
        }
    }
    EncerraPrograma();
}

int IniciaPrograma()
{
    Console.WriteLine(@"Sistema de Gestão de Contratos de Financiamento

Escolha a opção desejada:
1 - Cadastrar Contrato de Financiamento para Pessoa Física
2 - Cadastrar Contrato de Financiamento para Pessoa Jurídica
3 - Consultar Contratos Cadastrados
");
    int tipoCadastro = Validacoes.ConsoleIntIntervalo(1, 3);
    return tipoCadastro;
}

ContratoPessoaFisica CriaContratoPf()
{
    Console.WriteLine("Qual o nome do contratante?");
    string nomeContratante = Validacoes.ConsoleSemVazio();
    Console.Clear();
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
    Console.WriteLine("Qual o valor do financiamento?");
    decimal valorContrato = Validacoes.ConsoleDecimalPositivo();
    Console.Clear();
    Console.WriteLine("Qual o prazo do financiamento em meses?");
    int prazoContrato = Validacoes.ConsoleIntIntervalo(1, 240);

    Console.Clear();
    ContratoPessoaFisica contratoPf = new(nomeContratante, valorContrato, prazoContrato, cpfDigitado, dataNascimento);
    if (contratoPf.CalcularIdade() < 18)
    {
        Console.WriteLine("Não podemos realizar contrato de financiamento para menores de idade!\n");
        EncerraPrograma();
        Environment.Exit(0);
    }
    return contratoPf;
}

ContratoPessoaJuridica CriaContratoPj()
{
    Console.WriteLine("Qual o nome do contratante?");
    string nomeContratante = Validacoes.ConsoleSemVazio();
    Console.Clear();
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
    Console.Clear();
    Console.WriteLine("Qual o valor do financiamento?");
    decimal valorContrato = Validacoes.ConsoleDecimalPositivo();
    Console.Clear();
    Console.WriteLine("Qual o prazo do financiamento em meses?");
    int prazoContrato = Validacoes.ConsoleIntIntervalo(1, 240);

    ContratoPessoaJuridica contratoPj = new(nomeContratante, valorContrato, prazoContrato, cnpjDigitado, numeroInscricaoDigitado);
    return contratoPj;
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
        ExecutaPrograma();
    }
}

int EscolhaTipoConsulta()
{
    Console.WriteLine(@"Qual tipo de consulta deseja realizar?
1 - Consulta pelo nome do contratante 
2 - Consulta pelo CPF
3 - Consulta pelo CNPJ
4 - Consulta pelo número do contrato
");
    int tipoConsulta = Validacoes.ConsoleIntIntervalo(1, 4);
    return tipoConsulta;
}

void ConsultaPorNome(string nome)
{
    var contratosFiltrados1 = contratosPf.Where(c => c.Contratante.Contains(nome)).ToList();
    var contratosFiltrados2 = contratosPj.Where(c => c.Contratante.Contains(nome)).ToList();

    if (contratosFiltrados1.Any())
    {
        foreach (var contrato in contratosFiltrados1)
        {
            contrato.ExibirInfo();
        }
    }
    if (contratosFiltrados2.Any())
    {
        foreach (var contrato in contratosFiltrados2)
        {
            contrato.ExibirInfo();
        }
    }
    if (!contratosFiltrados1.Any() && !contratosFiltrados2.Any())
    {
        Console.WriteLine("Nenhum contrato encontrado.");
    }
}

void ConsultaPorCpf(string cpf)
{
    var contratosFiltrados = contratosPf.Where(c => c.Cpf == cpf).ToList();
    if (contratosFiltrados.Any())
    {
        foreach (var contrato in contratosFiltrados)
        {
            contrato.ExibirInfo();
        }
    }
    else
    {
        Console.WriteLine("Nenhum contrato encontrado.");
    }
}

void ConsultaPorCnpj(string cnpj)
{
    var contratosFiltrados = contratosPj.Where(c => c.Cnpj == cnpj).ToList();
    if (contratosFiltrados.Any())
    {
        foreach (var contrato in contratosFiltrados)
        {
            contrato.ExibirInfo();
        }
    }
    else
    {
        Console.WriteLine("Nenhum contrato encontrado.");
    }
}

void ConsultaPorNumero(string numero)
{
    var contratosFiltrados1 = contratosPf.Where(c => c.IdContrato.ToString() == numero).ToList();
    var contratosFiltrados2 = contratosPj.Where(c => c.IdContrato.ToString() == numero).ToList();

    if (contratosFiltrados1.Any())
    {
        foreach (var contrato in contratosFiltrados1)
        {
            contrato.ExibirInfo();
        }
    }
    if (contratosFiltrados2.Any())
    {
        foreach (var contrato in contratosFiltrados2)
        {
            contrato.ExibirInfo();
        }
    }
    if (!contratosFiltrados1.Any() && !contratosFiltrados2.Any())
    {
        Console.WriteLine("Nenhum contrato encontrado.");
    }
}