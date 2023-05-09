using SocialNetwork.Core.Application.Services;
using SocialNetwork.Core.Application.ViewModels;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.IServices
{
    public interface IPropertyService: IGenericService<Propiedad, SavePropertyViewModel, PropertyViewModel>
    {
    }
}
