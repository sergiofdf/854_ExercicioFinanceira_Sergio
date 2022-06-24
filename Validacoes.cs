using System.Text.RegularExpressions;

namespace _854_ExercicioFinanceira_Sergio
{
    public static class Validacoes
    {
        public static bool CpfValido(string cpf)
        {
            Regex RgxCpf = new(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$");
            if (!RgxCpf.Match(cpf).Success)
            {
                Console.WriteLine("CPF digitado inválido!\nDigite no formato 123.123.123-12");
                return false;
            }
            return true;
        }
        public static bool CnpjValido(string cnpj)
        {
            Regex RgxCnpj = new(@"^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}$");
            if (!RgxCnpj.Match(cnpj).Success)
            {
                Console.WriteLine("CNPJ digitado inválido!\nDigite no formato 12.123.123/0001-12");
                return false;
            }
            return true;
        }
        public static bool InscricaoValida(string inscricao)
        {
            Regex RgxInscricao = new(@"^(\d{3}\.?){3}\d{3}$");
            if (!RgxInscricao.Match(inscricao).Success)
            {
                Console.WriteLine("Inscrição digitada inválida!\nDigite no formato 123.456.789.123");
                return false;
            }
            return true;
        }
        public static string ConsoleSemVazio()
        {
            bool entradaValida = false;
            string entradaUsuario = "";
            while (!entradaValida)
            {
                entradaUsuario = Console.ReadLine();
                if (string.IsNullOrEmpty(entradaUsuario))
                {
                    Console.WriteLine("Informação Obrigatória. Digite algo...");
                }
                else
                {
                    entradaValida = true;
                }
            }
            return entradaUsuario;
        }
        public static int ConsoleIntIntervalo(int limteInferior, int limiteSuperior)
        {
            int numeroDigitado = 0;
            bool entradaIntlValida = false;
            while (!entradaIntlValida)
            {
                entradaIntlValida = int.TryParse(ConsoleSemVazio(), out numeroDigitado);
                if (!entradaIntlValida || numeroDigitado < limteInferior || numeroDigitado > limiteSuperior)
                {
                    Console.WriteLine("Digite um número válido...");
                    entradaIntlValida = false;
                }
            }
            return numeroDigitado;
        }
        public static decimal ConsoleDecimalPositivo()
        {
            decimal numeroDigitado = 0;
            bool entradaDecimalValida = false;
            while (!entradaDecimalValida)
            {
                entradaDecimalValida = decimal.TryParse(ConsoleSemVazio(), out numeroDigitado);
                if (!entradaDecimalValida || numeroDigitado <= 0)
                {
                    Console.WriteLine("Digite um número válido...");
                    entradaDecimalValida = false;
                }
            }
            return numeroDigitado;
        }
        public static DateTime ConsoleData()
        {
            DateTime dataDigitada = DateTime.MinValue;
            bool entradaDataValida = false;

            //Regex Data
            // \b([0-2]{0,1}[1-9]|(3)[0-1])(\/)(((0){0,1}[1-9])|((1)[0-2]))(\/)\d{4}\b

            while (!entradaDataValida)
            {
                entradaDataValida = DateTime.TryParse(ConsoleSemVazio(), out dataDigitada);
                if (!entradaDataValida)
                {
                    Console.WriteLine("Digite uma data válida no formato dd-mm-aaaa...");
                }
                if (dataDigitada >= DateTime.Now)
                {
                    Console.WriteLine("Data deve estar no passado...");
                    entradaDataValida = false;
                }
            }
            return dataDigitada;
        }
        public static bool VerificaMaioridade(int idade)
        {
            return idade >= 18;
        }
    }
}
