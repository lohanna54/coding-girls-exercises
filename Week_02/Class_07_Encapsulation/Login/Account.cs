namespace Class_07_Encapsulation.Login
{
	public class Account
	{
		public string User { get; }

		public string Password { get; private set; }

		public bool IsLoggedIn { get; private set; }

		public Account(string user, string password)
		{
			User = user;
			Password = password;
		}

		public void SetPassword(string password)
		{
			Password = password;
		}

		public void Login()
		{
			IsLoggedIn = true;
		}
	}
}
