using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{ 
    [EntityMapping("PostedComment", MappingType.TotalExplicit)]
    public class PostedCommentDTO : DTOBase
    {

        [EntityPropertyMapping(MappingDirectionType.Both, "EmailID")]//There is no entity like Sample that exists
        public string EmailID { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "BookReadingEventID")]//There is no entity like Sample that exists
        public int BookReadingEventID { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comments")]
        public string Comments { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedOn")]//There is no entity like Sample that exists
        public DateTime CreatedOn { get; set; }
    }
}
