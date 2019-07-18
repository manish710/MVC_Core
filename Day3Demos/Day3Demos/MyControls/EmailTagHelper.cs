using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Day3Demos.MyControls
{
    public class EmailTagHelper : TagHelper
    {
        //public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.TagName = "a";

        //    //return base.ProcessAsync(context, output);
        //    //return await 
        //}

        public string MailTo { get; set; }
        string emailDomain = "jlta.co.au";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", "mailto:" + MailTo + "@" + emailDomain);
            output.Content.Append(MailTo + "@" + emailDomain);
        }
    }
}
