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

namespace SocialNetwork.Core.Application.Features.Properties.Commands.DeleteProperty
{

    public class DeletePropertyById : IRequest<int>
    {

        public int id { get; set; }

    }


    public class DeletePropertyByIdCommandHandlers : IRequestHandler<DeletePropertyById, int>
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;

        public DeletePropertyByIdCommandHandlers(IMapper mapper, IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(DeletePropertyById query, CancellationToken cancellation)
        {
            Propiedad propiedades = await propertyRepository.GetByIDAsync(query.id);
            if (propiedades == null) throw new Exception("Mejora not found");
            await propertyRepository.DeleteAsync(propiedades);
            return propiedades.id;
        }

    }
}
