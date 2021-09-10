using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.Sample.BusinessFacades.dll", "Nagarro.Sample.BusinessFacades.UserFacade")]
        UserFacade = 1,

        [QualifiedTypeName("Nagarro.Sample.BusinessFacades.dll", "Nagarro.Sample.BusinessFacades.EventFacade")]
        EventFacade = 2,

        [QualifiedTypeName("Nagarro.Sample.BusinessFacades.dll", "Nagarro.Sample.BusinessFacades.PostedCommentsFacade")]
        PostedCommentsFacade = 3
    }
}
