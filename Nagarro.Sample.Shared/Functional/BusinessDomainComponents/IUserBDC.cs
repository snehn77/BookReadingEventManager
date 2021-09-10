﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public interface IUserBDC:IBusinessDomainComponent
    {
        OperationResult<UserDTO> SignUp(UserDTO UserDTO);
        OperationResult<LoginDTO> Login(LoginDTO UserDTO);
    }
}
