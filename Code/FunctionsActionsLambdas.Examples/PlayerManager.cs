using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionsActionsLambdas.Examples
{
	public class PlayerManager
	{
		public void Execute1()
		{
			var player = new Player();
			var status = player.GetStatus();
			//var reset = player.Reset();
			//var reset = player.Reset;
			//Action reset = player.Reset;
			var reset = (Action)player.Reset;
			reset();
			//var setPoints = (Action)player.SetPoints;
			var setPoints = (Action<int>)player.SetPoints;
			//setPoints();
			setPoints(10);
			//var getStatus = player.GetStatus;
			var getStatus = (Func<string>)player.GetStatus;
			var currentStatus = getStatus();
			var twentyResets = Enumerable.Repeat<Action>(player.Reset, 20).ToList();
			twentyResets.ForEach(r => r());
			setPoints.Invoke(20);
		}

		public void Execute2()
		{
			var values = new int[] { 1, 2, 3, 4, 5 };
			var evens = new List<int>();
			foreach (var value in values)
			{
				if (ValueIsEven(value))
				{
					evens.Add(value);
				}
			}
		}

		public void Execute3()
		{
			var values = new int[] { 1, 2, 3, 4, 5 };
			var evens = values.Where(ValueIsEven);
		}

		public void Execute4()
		{
			var values = new int[] { 1, 2, 3, 4, 5 };
			var evens = values.Where(value => ValueIsEven(value));
		}

		public void Execute5()
		{
			var values = new int[] { 1, 2, 3, 4, 5 };
			var evens = values.Where(value => value % 2 == 0);
		}

		int value;

		public void Execute6()
		{
			var player1 = new Player();
			var player2 = new Player();
			Action action;
			action = player1.Reset;
			action = () => { };
			action = () => value++;
			action = () => { value++; };
			Action<int> addToValue;
			addToValue = i => value += i;
			Action<int, int> addTwice = (a, b) => value += a + b;
			Func<int, int> square = i => i * i;
			var squareOfFour = square(4);
		}

		public void Execute7()
		{
			var list = new List<Func<int>>();
			for (var i = 0; i < 5; i++)
			{
				list.Add(() => i * 2);
			}
			list.ForEach(item => Console.WriteLine(item()));
		}

		public void Execute8()
		{
			var list = new List<Func<int>>();
			for (var i = 0; i < 5; i++)
			{
				var ib = i;
				list.Add(() => ib * 2);
			}
			list.ForEach(item => Console.WriteLine(item()));
		}

		private bool ValueIsEven(int value)
		{
			return value % 2 == 0;
		}
	}
}
