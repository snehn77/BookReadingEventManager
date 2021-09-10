using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.Sample.Shared;

namespace Nagarro.Sample.BusinessFacades
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }
        public OperationResult<UserDTO> SignUp(UserDTO userDTO)
        {
            IUserBDC sampleBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return sampleBDC.SignUp(userDTO);
        }

        public OperationResult<LoginDTO> Login(LoginDTO userDTO)
        {
            IUserBDC sampleBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return sampleBDC.Login(userDTO);
        }
    }
}
