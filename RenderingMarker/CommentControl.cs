using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Sitecore.Web.UI;

namespace RenderingMarker
{
    public class CommentControl :WebControl
    {
        public string Message { get; set; }

        public CommentControl()
        {
        }

        public CommentControl(string message)
        {
            this.Message = message;
        }

        protected override void DoRender(HtmlTextWriter output)
        {
            output.Write($"<!-- {System.Web.HttpUtility.HtmlEncode(Message)} -->");
        }
    }
}