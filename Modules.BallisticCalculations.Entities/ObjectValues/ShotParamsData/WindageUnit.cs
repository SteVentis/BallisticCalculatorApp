namespace Modules.BallisticCalculations.Services.ObjectValues.ShotParamsData
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