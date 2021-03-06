using System.Collections.Generic;

namespace Studle.BLL.Dto
{
    public class RoleDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserDto> Roles { get; set; }
    }
}
