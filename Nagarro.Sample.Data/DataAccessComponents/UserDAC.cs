using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Linq;

namespace Nagarro.Sample.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDAC : DACBase, IUserDAC
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserDTO"></param>
        /// <returns></returns>
        public UserDTO SignUp(UserDTO userDTO)
        {
            UserDTO retVal = null;
            try
            {
                using(EventDbContext dbContext = new EventDbContext())
                {
                    int isExsist = dbContext.Users.Where(x => x.Email == userDTO.Email).ToList().Count();
                    if (isExsist == 0)
                    {
                        User user = new User
                        {
                            CreatedOn = DateTime.Now,
                            ModifiedOn = DateTime.Now
                        };
                        string password = userDTO.Password;
                        userDTO.Password = PasswordHasher.Encrypt(password, PasswordHasher.EncryptionKey);
                        EntityConverter.FillEntityFromDTO(userDTO, user);
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        retVal = userDTO;
                    }
                    else
                    {
                        return retVal;
                    }
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public LoginDTO Login(LoginDTO userDTO)
        {
           LoginDTO retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    userDTO.Password = PasswordHasher.Encrypt(userDTO.Password, PasswordHasher.EncryptionKey);
                    var isExsist = dbContext.Users.Where(x => (x.Email == userDTO.Email && x.Password == userDTO.Password)).ToList();
                    if (isExsist.Count != 0)
                    {
                        foreach(var i in isExsist)
                        {
                            userDTO.ID = i.ID;
                            break;
                        }
                        retVal = userDTO;
                        return retVal;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }
    }
}
