using System;

namespace FunctionsActionsLambdas.Examples
{
	public interface IPlayer
	{
		void Reset();
		void SetPoints(int points);
		string GetStatus();
	}
}
