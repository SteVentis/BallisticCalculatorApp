namespace Modules.BallisticCalculations.Core.ObjectValues.ShotParamsData
{
    public class WindageUnit<TUnit>
    {
        public WindageUnit(TUnit unit)
        {
            Unit = unit;
        }

        public TUnit Unit { get; }
    }
}