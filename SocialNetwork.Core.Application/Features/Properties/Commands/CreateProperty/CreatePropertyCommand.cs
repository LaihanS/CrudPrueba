using AutoMapper;
using MediatR;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Core.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequest<int>
    {

        public string Name { get; set; }

        public int Price { get; set; }

    }

    public class CreatePropertyCommandCommandHandlers : IRequestHandler<CreatePropertyCommand, int>
    {

        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;
      
        public CreatePropertyCommandCommandHandlers(IMapper mapper, IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var propiedad = mapper.Map<PropertyDto>(request);
            propiedad = mapper.Map<PropertyDto>(await propertyRepository.AddAsync(mapper.Map<Propiedad>(propiedad)));
            return propiedad.id;
        }


    }
}
