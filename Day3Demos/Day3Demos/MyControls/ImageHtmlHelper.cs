using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day3Demos.MyControls
{
    public static class ImageHtmlHelper
    {
        public static IHtmlContent Image(this IHtmlHelper helper, string src, string alt, string width, string height)
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.Attributes.Add("src", @src);
            tagBuilder.Attributes.Add("alt", alt);
            tagBuilder.Attributes.Add("width", width);
            tagBuilder.Attributes.Add("height", height);
            tagBuilder.RenderSelfClosingTag();
            return tagBuilder;
        }
    }
}
