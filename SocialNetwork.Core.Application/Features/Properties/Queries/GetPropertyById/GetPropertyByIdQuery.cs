using AutoMapper;
using MediatR;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.IRepositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Features.Properties.Queries.GetPropertyById
{
    public class GetPropertyByIdQuery : IRequest<PropertyDto>
    {
        [SwaggerParameter(Description = "Id de la mejora")]
        public int id { get; set; }
    }
    public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDto>
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;

        public GetPropertyByIdQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }
        public async Task<PropertyDto> Handle(GetPropertyByIdQuery query, CancellationToken cancellationToken)
        {
            var properties = await propertyRepository.GetAllAsync();
            var property = properties.FirstOrDefault(w => w.id == query.id);
            if (property == null) throw new Exception($"Property Not Found.");
            var propertyvm = mapper.Map<PropertyDto>(property);

            return propertyvm;
        }
    }

}
