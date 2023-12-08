using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Security.Domain.Shared;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsFailure { get; }
}
