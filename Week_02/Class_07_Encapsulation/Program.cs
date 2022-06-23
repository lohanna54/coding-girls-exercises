using Class_07_Encapsulation.Login;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace Class_07_Encapsulation
{
	public static class Program
	{
		private static readonly Cryptography Hash = new(SHA512.Create());

		public static void Main()
		{
			Console.WriteLine("\n--- Sistema de Login ---\n");
			Console.WriteLine("1. Criar conta\n2. Alterar senha\n3. Acessar sistema");

			if (int.TryParse(Console.ReadLine(), out int selectedOption) && selectedOption is >= 1 and <= 3)
			{
				switch (selectedOption)
				{
					case 1:
						CreateAccount();
						break;
					case 2:
						ChangePassword();
						break;
					case 3:
						Login();
						break;
				}

				AskToExecuteAgain();
			}
			else
			{
				Console.WriteLine("Opção inválida");
			}
		}

		public static void CreateAccount()
		{
			Console.WriteLine("Informe seu nome de usuário");
			var name = Console.ReadLine();

			if (!Accounts.IsAnExistentUser(name))
			{
				Console.WriteLine("Escolha sua senha");
				var password = Console.ReadLine();

				var user = new Account(name, Hash.PasswordEncrypt(password));
				Accounts.SetAccount(user);

				Console.WriteLine("Usuário salvo com sucesso");
			}
			else
			{
				Console.WriteLine("Este usuário já existe!");
			}
		}

		public static void ChangePassword()
		{
			Console.WriteLine("Informe seu nome de usuário");
			var name = Console.ReadLine();

			var user = Accounts.GetAccount(name);

			if (user != null)
			{
				Console.WriteLine("Escolha sua nova senha");
				var password = Console.ReadLine();

				user.SetPassword(Hash.PasswordEncrypt(password));

				Accounts.Update(user);

				Console.WriteLine("Usuário salvo com sucesso");
			}
			else
			{
				Console.WriteLine("Este usuário não existe!");
			}
		}

		public static void Login()
		{
			Console.WriteLine("Informe seu nome de usuário");
			var name = Console.ReadLine();

			var user = Accounts.GetAccount(name);

			if (user != null)
			{
				Console.WriteLine("Informe sua senha");
				var password = Console.ReadLine();

				if(Accounts.LoginSucceed(user, password))
				{
					Console.WriteLine("Bem vindo ao sistema!");
				}
				else
				{
					Console.WriteLine("Senha incorreta!");
				}
			}
			else
			{
				Console.WriteLine("Este usuário não existe!");
			}
		}

		public static void AskToExecuteAgain()
		{
			Console.WriteLine("\nDeseja realizar outra operação? S/N");
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

