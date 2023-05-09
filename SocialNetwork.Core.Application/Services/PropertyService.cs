using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Core.Application.IServices;
using SocialNetwork.Core.Application.ViewModels;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class PropertyService: GenericService<Propiedad, SavePropertyViewModel, PropertyViewModel>, IPropertyService
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper): base(mapper, propertyRepository)
        {
            this.mapper = mapper;
            this.propertyRepository = propertyRepository;
        }
        
    }
}
