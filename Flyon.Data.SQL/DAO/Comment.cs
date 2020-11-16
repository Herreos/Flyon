using System;
using System.Collections.Generic;

namespace Flyon.Data.SQL.DAO
{
    public class Comment
    {
        public Comment()
        {
            SubComments = new List<Comment>();
        }
        
        public int CommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsActiveComment { get; set; }
        public bool IsBannedComment { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> SubComments { get; set; }
    }
}