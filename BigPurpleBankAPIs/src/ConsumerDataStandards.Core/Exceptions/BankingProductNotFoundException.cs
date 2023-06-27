namespace ConsumerDataStandards.Core.Exceptions
{
	public class BankingProductNotFoundException : Exception
	{
		public BankingProductNotFoundException()
		{
		}

        public BankingProductNotFoundException(string message) : base(message)
        {
        }
    }
}

