using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.BusinessFacades
{
    public class PostedCommentsFacade :FacadeBase, IPostedCommentsFacade
    {
        public PostedCommentsFacade()
            : base(FacadeType.PostedCommentsFacade)
        {

        }

        public OperationResult<PostedCommentDTO> PostComment(PostedCommentDTO commentDTO)
        {
            IPostedCommentsBDC sampleBDC = (IPostedCommentsBDC)BDCFactory.Instance.Create(BDCType.PostedCommentsBDC);
            return sampleBDC.PostComment(commentDTO);
        }
    }
}
