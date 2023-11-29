using BallisticCalculator;
using Modules.BallisticCalculations.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.BallisticCalculations.Core.Abstractions.IBuilder.IDirector;

public interface ITrajectoryPointCalculator
{
    Task<List<TrajectoryPoint>> GenerateTrajectoryPoints(InputBallisticData inputBallisticData);
}
