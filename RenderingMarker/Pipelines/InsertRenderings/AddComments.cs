using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Pipelines.InsertRenderings;

namespace RenderingMarker.Pipelines.InsertRenderings
{
    public class AddComments : InsertRenderingsProcessor
    {
        public override void Process(InsertRenderingsArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            if (!args.HasRenderings || args.ContextItem == null)
                return;

            for (var i = args.Renderings.Count - 1; i >= 0; i--)
            {
                var name = args.Renderings[i]?.RenderingItem?.DisplayName;
                var placeholder = args.Renderings[i]?.Placeholder;
                args.Renderings.Insert(i+1, new RenderingReference(new CommentControl($"End rendering: {name ?? "unknown"}")) { Placeholder = placeholder });
                args.Renderings.Insert(i, new RenderingReference(new CommentControl($"Begin rendering: {name ?? "unknown"}")) { Placeholder = placeholder });
            }

        }
    }
}