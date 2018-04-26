using System;

namespace FunctionsActionsLambdas.Examples
{
	public abstract class PlayerBase
	{
		public abstract void Reset();
		public abstract void SetPoints(int points);
		public abstract string GetStatus();
	}
}
