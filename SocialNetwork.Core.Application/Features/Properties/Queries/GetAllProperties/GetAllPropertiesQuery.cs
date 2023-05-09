using AutoMapper;

using MediatR;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<IEnumerable<PropertyDto>>
    {
    }
    public class GetAllMejorasQueryHandler : IRequestHandler<GetAllPropertiesQuery, IEnumerable<PropertyDto>>
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;

        public GetAllMejorasQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var categoriesViewModel = mapper.Map<IEnumerable<PropertyDto>>(await propertyRepository.GetAllAsync());
            if (categoriesViewModel == null || categoriesViewModel.Count() == 0) throw new Exception("No Properties Found");
            return categoriesViewModel;
        }

       
    }
}
