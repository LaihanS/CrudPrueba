using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.Features.Properties.Commands.CreateProperty;
using SocialNetwork.Core.Application.Features.Properties.Commands.UpdateProperty;
using SocialNetwork.Core.Application.ViewModels;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Mappings
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile() {
            CreateMap<Propiedad, PropertyViewModel>().ReverseMap();

            CreateMap<Propiedad, SavePropertyViewModel>().ReverseMap();

            CreateMap<PropertyViewModel, SavePropertyViewModel>().ReverseMap();

            CreateMap<Propiedad, PropertyDto>().ReverseMap();

            CreateMap<CreatePropertyCommand, PropertyDto>().ReverseMap();

            CreateMap<UpdatePropertyCommand, PropertyDto>().ReverseMap();

            CreateMap<UpdatePropertyCommand, Propiedad>().ReverseMap();


        }

    }
}
