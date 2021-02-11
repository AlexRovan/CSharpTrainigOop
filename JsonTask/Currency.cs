namespace JsonTask
{
    public class Currency
    {
        public string Code { get; }

        public string Name { get; }

        public string Symbol { get; }

        public Currency(string code, string name, string symbol)
        {
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
