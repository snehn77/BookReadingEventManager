using Nagarro.Sample.Shared;
using Nagarro.Sample.Validations;
using System;

namespace Nagarro.Sample.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBDC : BDCBase, IUserBDC
    {
        private readonly IDACFactory dacFacotry;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public UserBDC()
            : base(BDCType.UserBDC)
        {
            dacFacotry = DACFactory.Instance;
        }

        public UserBDC(IDACFactory dacFacotry)
            : base(BDCType.UserBDC)
        {
            this.dacFacotry = dacFacotry;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserDTO"></param>
        /// <returns></returns>
        public OperationResult<UserDTO> SignUp(UserDTO UserDTO)
        {
            OperationResult<UserDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<SampleValidator, UserDTO>.Validate(UserDTO);
                if (validationResult.IsValid)
                {
                    IUserDAC sampleDAC = (IUserDAC)dacFacotry.Create(DACType.UserDAC);
                    UserDTO resultDTO = sampleDAC.SignUp(UserDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<UserDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<UserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
        public OperationResult<LoginDTO> Login(LoginDTO UserDTO)
        {
            OperationResult<LoginDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<LoginValidator, LoginDTO>.Validate(UserDTO);
                if (validationResult.IsValid)
                {
                    IUserDAC sampleDAC = (IUserDAC)dacFacotry.Create(DACType.UserDAC);
                    LoginDTO resultDTO = sampleDAC.Login(UserDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<LoginDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<LoginDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<LoginDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<LoginDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<LoginDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
