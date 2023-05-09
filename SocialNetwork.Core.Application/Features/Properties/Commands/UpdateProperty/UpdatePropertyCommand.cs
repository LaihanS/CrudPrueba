using AutoMapper;
using MediatR;
using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Core.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SocialNetwork.Core.Application.Features.Properties.Commands.UpdateProperty
{
  
    public class UpdatePropertyCommand : IRequest<int>
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

    }


    public class UpdatePropertyCommandHandlers : IRequestHandler<UpdatePropertyCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;
        

        public UpdatePropertyCommandHandlers(IPropertyRepository propertyRepository, IMapper mapper)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(UpdatePropertyCommand command, CancellationToken cancellation)
        {
            var category = await propertyRepository.GetByIDAsync(command.id);
            if (category == null)
            {
                throw new Exception("Property not found");
            }
            else
            {
                category = mapper.Map<Propiedad>(command);
                await propertyRepository.UpdateAsync(category, category.id);
                return category.id;
            }
        }

    }
}
