namespace Nagarro.Sample.Shared
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "FirstName")]//There is no entity like Sample that exists
        public string FirstName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "LastName")]
        public string LastName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]//There is no entity like Sample that exists
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password{ get; set; }
    }
}
