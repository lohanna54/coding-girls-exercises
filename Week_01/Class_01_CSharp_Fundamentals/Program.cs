using System;
using System.Collections.Generic;

namespace Class_01_CSharpFundamentals
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Elabore um programa que escreve seu nome completo, seu endereço, o CEP e telefone em linhas separadas.\n" +
                "2. Escolha uma mulher famosa na história da tecnologia e implemente um programa que escreve seu nome, sua formação e uma contribuição feita por ela dentro da tecnologia em linhas separadas.\n" +
                "3. Elabore um programa que mostre na tela uma letra de música que você gosta, o compositor e o gênero musical em linhas separadas.\n" +
                "4. Elabore um programa que exibe uma mensagem que incentive outras mulheres a entrar na tecnologia.");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        ShowResumeData();
                        break;
                    case 2:
                        ShowWomenOfTechnology();
                        break;
                    case 3:
                        ShowMusicLyrics();
                        break;
                    case 4:
                        ShowEncouragingPhrases();
                        break;
                    default:
                        Console.WriteLine("Por favor, envie uma das opções:\n");
                        Main();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Por favor, envie somente números:\n");
                Main();
            }

            AskToExecuteAgain();
        }

        public static void ShowResumeData()
        {
            Console.WriteLine("Nome: Lohanna Almeida\nCEP: 31999-999\nTEL: 31 9 9999-9999");
        }

        public static void ShowWomenOfTechnology()
        {
            Console.WriteLine("Nome: Marian Rogers Croak");
            Console.WriteLine("Posição: Cientista da computação");
            Console.WriteLine("Feito: É vice-presidente de engenharia do Google. Anteriormente, ela foi vice-presidente sênior de pesquisa e desenvolvimento da AT&T.\n" +
                "Em 2013, Croak foi introduzida ao Women in Technology International Hall of Fame.\n" +
                "Em 2022, ela foi introduzida ao National Inventors Hall of Fame por sua patente sobre a tecnologia VoIP (Voice over Internet Protocol).\n" +
                "É uma das duas primeiras mulheres negras a receber essa honra, junto com Patricia Bath.\n" +
                "Sua invenção permite que os usuários façam chamadas pela internet em vez de uma linha telefônica.\n" +
                "Hoje, o uso generalizado da tecnologia VoIP é vital para trabalho remoto e conferências.");
        }

        public static void ShowMusicLyrics()
        {
            const string ARTIST_NAME = "Cicero Rosa Lins";
            const string ALBUM_NAME = "Canções de Apartamento";
            const string GENRE_NAME = "MPB; Indie rock";

            var lyrics = new List<string>
            {
                "\nQuando" +
                "\nDe vez em quando" +
                "\nTalvez um tanto" +
                "\nFaz tanto fez" +
                "\nPassando a vez" +
                "\nDe par em par" +
                "\nLe petit prince égoiste" +
                "\nE sua flor de uísque" +
                "\nEm seu planeta sem cor" +
                "\nMas quem se importa?",

                "\nSomos" +
                "\nA vez dos zonzos" +
                "\nTalvez enquanto" +
                "\nQuisermos ser" +
                "\nDaqui pra já" +
                "\nEu e você" +
                "\nDaqui pra lá" +
                "\nNão vai sobrar" +
                "\nNada pra ser" +
                "\nMas quem se importa?",

                "\nÉ sexta-feira, amor" +
                "\nSexta-feira" +
                "\nÉ sexta-feira, amor" +
                "\nSexta-feira",

                "\nTanto" +
                "\nFaz qualquer canto" +
                "\nPra qualquer santo" +
                "\nQue saiba ler" +
                "\nQue queira dar" +
                "\nSem receber" +
                "\nQue esteja a par" +
                "\nDo que vai ver" +
                "\nDe onde vai dar" +
                "\nMas quem se importa?",

                "\nÉ sexta-feira, amor" +
                "\nSexta-feira" +
                "\nÉ sexta-feira, amor" +
                "\nSexta-feira" +
                "\nÉ sexta-feira, amor" +
                "\nSexta-feira" +
                "\nÉ sexta-feira, amor" +
                "\nSexta-feira",

                "\nTem quem queira",

                "\nÉ sexta-feira, amor" +
                "\nSexta-feira" +
                "\nÉ sexta-feira, amor" +
                "\nSexta-feira"
            };

            foreach (var verses in lyrics)
            {
                Console.WriteLine(verses);
                System.Threading.Thread.Sleep(2000);
            }

            Console.WriteLine($"\nArtista: {ARTIST_NAME}");
            Console.WriteLine($"Álbum: {ALBUM_NAME}");
            Console.WriteLine($"Gênero: {GENRE_NAME}");
        }

        public static void ShowEncouragingPhrases()
        {
            Console.WriteLine("Vamo, galera!\nMULHERES!");
        }

        public static void AskToExecuteAgain()
        {
            Console.WriteLine("\nExecutar novamente? Digite S para continuar e qualquer tecla para SAIR");
            var executeAgain = Console.ReadLine();

            if (string.Equals(executeAgain, "s", StringComparison.OrdinalIgnoreCase))
            {
                Main();
            }
            else
            {
                Console.WriteLine("Finalizando...");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
