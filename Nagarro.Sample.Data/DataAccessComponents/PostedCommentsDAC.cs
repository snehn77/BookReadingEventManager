using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Data
{
    public class PostedCommentsDAC : DACBase, IPostedCommentsDAC
    {
        public PostedCommentsDAC()
           : base(DACType.PostedCommentsDAC)
        {

        }

        public PostedCommentDTO PostComment(PostedCommentDTO commentDTO)
        {
            PostedCommentDTO retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    PostedComment comment = new PostedComment
                    {
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        BookReadingEventID = commentDTO.BookReadingEventID,
                        EmailID = commentDTO.EmailID,
                        Comments = commentDTO.Comments,                    
                    };
                    dbContext.PostedComments.Add(comment);
                    dbContext.SaveChanges();
                    retVal = commentDTO;
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
