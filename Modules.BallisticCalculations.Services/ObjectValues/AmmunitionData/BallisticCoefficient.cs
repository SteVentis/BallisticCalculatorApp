using Modules.BallisticCalculations.Services.Enums;

namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public readonly struct BallisticCoefficient
{
    public double Value { get; }

    public Drag Drag { get; }

    public BallisticCoefficient(double value, Drag drag)
    {
        Value = value;
        Drag = drag;
    }
}
