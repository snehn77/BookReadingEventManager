namespace Nagarro.Sample.Shared
{
   [EntityMapping("Login", MappingType.TotalExplicit)]
   public class LoginDTO : DTOBase
   {
       [EntityPropertyMapping(MappingDirectionType.Both, "ID")]//There is no entity like Sample that exists
        public int ID { get; set; }

       [EntityPropertyMapping(MappingDirectionType.Both, "Email")]//There is no entity like Sample that exists
       public string Email { get; set; }

       [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
       public string Password { get; set; }
   } 
}
