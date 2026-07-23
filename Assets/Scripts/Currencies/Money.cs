namespace Currencies
{
    public class Money : SaveableCurrency
    {
        public Money()
            : base(CurrencyType.Money)
        {
        }
    }
}