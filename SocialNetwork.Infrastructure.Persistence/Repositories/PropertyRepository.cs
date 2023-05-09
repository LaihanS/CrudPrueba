using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class PropertyRepository: GenericRepository<Propiedad>, IPropertyRepository
    {
        private readonly ApplicationContext context;
        public PropertyRepository(ApplicationContext context): base(context) 
        {
            this.context = context;
        }

    }
}
