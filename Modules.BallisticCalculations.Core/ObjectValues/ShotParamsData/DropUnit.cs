namespace Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData;

public sealed record DropUnit<TUnit>
{
    public DropUnit(TUnit unit)
    {
        Unit = unit;
    }

    public TUnit Unit { get; }
}
