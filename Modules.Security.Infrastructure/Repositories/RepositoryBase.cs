using Microsoft.AspNetCore.Identity;
using Modules.Security.Domain.Models;
using Modules.Security.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Security.Infrastructure.Repositories
{
    internal class RepositoryBase
    {
        protected readonly IdentityAppDbContext _dbContext;
        protected readonly UserManager<User> _userManager; 
        public RepositoryBase(IdentityAppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
    }
}
