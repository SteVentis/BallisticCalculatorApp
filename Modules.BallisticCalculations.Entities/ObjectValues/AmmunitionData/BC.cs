using BallisticCalculator;

namespace Modules.BallisticCalculations.Core.ObjectValues.AmmunitionData;

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
