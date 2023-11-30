namespace Modules.BallisticCalculations.Core.ObjectValues.RifleData
{
    public sealed record RifleName
    {
        public RifleName(string value)
        {
            Value = value;
        }

        public string Value { get; }

    }
}
