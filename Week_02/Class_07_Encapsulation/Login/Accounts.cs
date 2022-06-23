using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Class_07_Encapsulation.Login
{
	public static class Accounts
	{
		private static readonly IList<Account> RegisteredAccounts;
		private static readonly Cryptography Hash = new(SHA512.Create());

		static Accounts()
		{
			RegisteredAccounts = new List<Account>();
		}

		public static void SetAccount(Account account)
		{
			RegisteredAccounts.Add(account);
		}

		public static bool IsAnExistentUser(string userName)
		{
			return RegisteredAccounts.Any(r => r.User == userName);
		}

		public static bool LoginSucceed(Account account, string password)
		{
			var succeed = Hash.IsValidPassword(password, account.Password);

			if (succeed) {
				account.Login();
			}

			return succeed;
		}

		public static Account GetAccount(string userName)
		{
			return RegisteredAccounts.FirstOrDefault(r => r.User == userName);
		}

		public static void Update(Account account)
		{
			var oldAccount =  RegisteredAccounts.First(r => r.User == account.User);
			RegisteredAccounts.Remove(oldAccount);

			SetAccount(account);
		}
	}
}
