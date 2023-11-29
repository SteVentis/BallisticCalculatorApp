using BallisticCalculator;

namespace Modules.BallisticCalculations.Services.ObjectValues.AmmunitionData;

public sealed record BC
{

    public BC(double value, DragTableId dragTable)
    {
        Value = value;
        DragTable = dragTable;
    }

    public double Value { get; }

    public DragTableId DragTable { get; }

}
