using _854_ExercicioFinanceira_Sergio;

//Teste Pessoa Física
Console.WriteLine("Teste Pessoa Física");
Console.WriteLine();
DateTime nascimentoPf1 = new DateTime(1989, 06, 01);
ContratoPessoaFisica contratoPf1 = new("José Silva", 10000, 10, "123.456.789-96", nascimentoPf1);
contratoPf1.ExibirInfo();

//Teste Pessoa Jurídica
Console.WriteLine();
Console.WriteLine("Teste Pessoa Jurídica");
Console.WriteLine();

ContratoPessoaJuridica contratoPj1 = new("Lets Pet", 30000, 60, "40.078.334/0001-00", "688.241.069.456");
contratoPf1.ExibirInfo();
