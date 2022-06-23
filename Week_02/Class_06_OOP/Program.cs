using Class_06_OOP.ComputerShop;
using Class_06_OOP.Extensions;
using Class_06_OOP.SalaryManagement;
using Class_06_OOP.TicTacToe_v2;
using System;
using System.Threading;

namespace Class_06_OOP
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n--- Exercícios ---\n");
            Console.WriteLine("1. Jogo da Velha" +
                "\nRegras:" +
                "\n- A classe deve conter como dados privados uma matriz 3x3 para representar a grade do jogo" +
                "\n- O construtor deve inicializar a matriz vazia" +
                "\n- Forneça um método para exibir a matriz com status do jogo" +
                "\n- Permita dois jogadores humanos" +
                "\n- Forneça um método para jogar o jogo; todo movimento deve ocorrer em uma casa vazia; depois de cada movimento valide se uma vitória ou um empate.\n\n" +

                "2. Gerenciando Salários" +
                    "\nRegras: " +
                    "\n  Classe Empregado que inclui os seguintes atributos: nome, cargo e salário mensal." +
                    "\n- Se o salário mensal não for positivo, configure-o como 0.0." +
                    "\n- Salário de 0 até 400.00 ganha 15% " +
                    "\n- Salário de 400.01 até 800.00 ganha 12%" +
                    "\n- Salário de 800.01 até 1200.00 ganha 10%" +
                    "\n- Salário de 1200.01 até 2000.00 ganha 7%" +
                    "\n- Acima de 2000.00 ganha 4%." +
                    "\n- Imprimir o salário de um funcionário.\n\n" +

                "3. Crie uma classe que representa uma fatura para uma loja de suprimentos de informática." +
                    "\nA classe deve conter os seguintes atributos: número, descrição dos produtos, quantidade comprada de um produto e o preço." +
                    "\nA classe deve ter um construtor e um método get e set para cada variável de instância." +
                    "\nAlém disso, forneça um método para calcular o valor total da fatura.\n\n" +

                "4. Fazer uma classe que represente um Sorteio que irá sortear um número de 0 a 1000 e após pedir para o usuário adivinhar este número. " +
                    "\nSe ele errar, informar se o palpite é maior ou menor do que o número sorteado. " +
                    "\nO usuário pode jogar até que acerte e, depois disso, mostrar quantas tentativas ele fez até acertar.\n\n" +

                "5. Montar uma classe que manipula strings. " +
                    "\nRegras:" +
                    "\nFaça um método que receba um nome completo e mostre a abreviatura deste nome. " +
                    "\nNão se devem abreviar as palavras com 2 ou menos letras. A abreviatura deve vir separada por pontos." +
                    "\nFazer um método que receba uma string do usuário e mostre o conteúdo desta string de forma invertida." +
                    "\nFazer um método que receba uma string e conte suas vogais e consoantes.");

            try
            {
                Console.WriteLine("\nEscolha o número do excercício que deseja ver a resolução:");
                var numberAnswer = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (numberAnswer)
                {
                    case 1:
                        TicTacToe.Play();
                        break;
                    case 2:
                        Management.Start();
                        break;
                    case 3:
                        Shop.Start();
                        break;
                    case 4:
                        NumericalDraw.NumericalDraw.Start();
                        break;
                    case 5:
                        StringExtensions.Start();
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
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}

