using System;
using FunctionsActionsLambdas.Examples;

namespace FunctionsActionsLambdas.ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var manager = new PlayerManager();
			manager.Execute7();
			Console.ReadKey();
		}
	}
}
