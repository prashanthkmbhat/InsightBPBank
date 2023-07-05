namespace ConsumerDataStandards.Core.Exceptions
{
	public class BankingProductNotFoundException : Exception
	{
        public BankingProductNotFoundException(string message) : base(message)
        {
        }
    }
}

