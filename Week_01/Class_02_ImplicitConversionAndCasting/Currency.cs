namespace Class_02_ImplicitConversionAndCasting
{
    public class Currency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public float ValueInBRL { get; set; }

        public Currency(string name, string symbol, float brlValue)
        {
            Name = name;
            Symbol = symbol;
            ValueInBRL = brlValue;
        }
    }
}
