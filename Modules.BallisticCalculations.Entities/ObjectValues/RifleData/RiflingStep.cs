namespace Modules.BallisticCalculations.Core.ObjectValues.RifleData;

public sealed record RiflingStep<Tunit>
{
    public RiflingStep(double value, Tunit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double Value { get; }
    public Tunit Unit { get; }
}
