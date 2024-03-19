using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Takaku.Models.ViewModels;

//This is new tag helper
namespace Mission11_Takaku.Infrastructure
{
    //Set this tag target element for div, and attribute of page-model
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper: TagHelper
    {
        //Access to the data and values using _urlHelperFactory
        private IUrlHelperFactory _urlHelperFactory;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            _urlHelperFactory = temp;
        }

        //These public get values from index.cshtml page.
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }

        public bool PageClassEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal {  get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        //This is processing the URL improvement. Making href link to change the page and receive new values for that page.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalNumPages; i++) 
                {
                    TagBuilder tag = new TagBuilder("a");

                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
