using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Features.Properties.Commands.UpdateProperty
{
    public class UpdatePropertyResponse
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Price { get; set; }
    }
}
