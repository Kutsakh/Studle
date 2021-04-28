using Studle.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studle.BLL.Dto
{
    class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserDto> Roles { get; set; }
    }
}
