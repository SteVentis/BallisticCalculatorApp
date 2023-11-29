using BallisticCalculator;
using Modules.BallisticCalculations.Core.Abstractions;
using Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;
using Modules.BallisticCalculations.Core.Models;
using Modules.BallisticCalculations.Services.Models;

namespace Modules.BallisticCalculations.Services;

internal sealed class BallisticCardService : IBallisticCardService
{
   
    private readonly ITrajectoryPointCalculator _calculator;

    public BallisticCardService(ITrajectoryPointCalculator calculator)
    {
        _calculator = calculator;
    }

    public async Task<List<TrajectoryPoint>> GenerateBallisticCard(InputBallisticData data)
    {
        var trajectoryPoints = await _calculator.GenerateTrajectoryPoints(data);

        TrajectoryValues trajectoryValues;

        List<TrajectoryValues> listOfTrajectoryValues = new List<TrajectoryValues>();

        foreach (var trajectory in trajectoryPoints)
        {
            trajectoryValues = new TrajectoryValues();
            trajectoryValues.Distance = trajectory.Distance.In(data.RifleData.ZeroAtDistance.Unit);
            trajectoryValues.Elevation = trajectory.DropAdjustment.In(data.ShotParamsData.DropUnit.Unit);
            trajectoryValues.Windage = trajectory.WindageAdjustment.In(data.ShotParamsData.WindageUnit.Unit);
            trajectoryValues.ToF = trajectory.Time.TotalSeconds;

            listOfTrajectoryValues.Add(trajectoryValues);
        }


        return trajectoryPoints;
    }
    
}
