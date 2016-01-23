using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Comment : Post
    {
        public Post CommentOp { get; set; }

        public Comment(int postId, string titel, string omschrijving, DateTime date, Post commentOp)
            : base(postId, titel, omschrijving, date)
        {
            CommentOp = commentOp;
        }
    }
}