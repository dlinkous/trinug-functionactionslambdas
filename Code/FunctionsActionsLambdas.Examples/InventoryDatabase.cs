using System;
using System.Data.SqlClient;

namespace FunctionsActionsLambdas.Examples
{
	public class InventoryDatabase
	{
		private const string connectionString = @"Server=.;Database=Inventory;Trusted_Connection=true;";

		public void ClearAllStatusFields1()
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = "UPDATE Widgets SET Status = ''";
					com.ExecuteNonQuery();
				}
			}
		}

		public void RemoveByClassification1(int classification)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = "DELETE Widgets WHERE Classification = @Classification";
					com.Parameters.AddWithValue("@Classification", classification);
					com.ExecuteNonQuery();
				}
			}
		}

		public void ClearAllStatusFields2()
		{
			UsingCommand(ClearAllStatusFieldsUsingCommand);
		}

		public void ClearAllStatusFieldsUsingCommand(SqlCommand com)
		{
			com.CommandText = "UPDATE Widgets SET Status = ''";
			com.ExecuteNonQuery();
		}

		//public void RemoveByClassification2(int classification)
		//{
		//	UsingCommand(RemoveByClassificationUsingCommand, classification);
		//}

		private int classification;

		public void RemoveByClassification2(int classification)
		{
			this.classification = classification;
			UsingCommand(RemoveByClassificationUsingCommand);
		}

		public void RemoveByClassificationUsingCommand(SqlCommand com)
		{
			com.CommandText = "DELETE Widgets WHERE Classification = @Classification";
			com.Parameters.AddWithValue("@Classification", classification);
			com.ExecuteNonQuery();
		}

		public void ClearAllStatusFields3()
		{
			UsingCommand(com =>
			{
				com.CommandText = "UPDATE Widgets SET Status = ''";
				com.ExecuteNonQuery();
			});
		}

		public void RemoveByClassification3(int classification)
		{
			UsingCommand(com =>
			{
				com.CommandText = "DELETE Widgets WHERE Classification = @Classification";
				com.Parameters.AddWithValue("@Classification", classification);
				com.ExecuteNonQuery();
			});
		}

		private void UsingCommand(Action<SqlCommand> action)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					action(com);
				}
			}
		}
	}
}
