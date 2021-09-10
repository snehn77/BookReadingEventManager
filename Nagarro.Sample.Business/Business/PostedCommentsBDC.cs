using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Business
{
    public class PostedCommentsBDC : BDCBase, IPostedCommentsBDC
    {
        private readonly IDACFactory dacFacotry;
        /// <summary>
        /// 
        /// </summary>
        public PostedCommentsBDC()
            : base(BDCType.PostedCommentsBDC)
        {
            dacFacotry = DACFactory.Instance;
        }

        public PostedCommentsBDC(IDACFactory dacFacotry)
            : base(BDCType.PostedCommentsBDC)
        {
            this.dacFacotry = dacFacotry;
        }

        public OperationResult<PostedCommentDTO> PostComment(PostedCommentDTO commentDTO)
        {
            OperationResult<PostedCommentDTO> retVal = null;
            IPostedCommentsDAC sampleDAC = (IPostedCommentsDAC)dacFacotry.Create(DACType.PostedCommentsDAC);
            PostedCommentDTO resultDTO = sampleDAC.PostComment(commentDTO);
            if (resultDTO != null)
            {
                retVal = OperationResult<PostedCommentDTO>.CreateSuccessResult(resultDTO);
            }
            else
            {
                retVal = OperationResult<PostedCommentDTO>.CreateFailureResult("Failed!");
            }

            return retVal;
        }
    }
}
