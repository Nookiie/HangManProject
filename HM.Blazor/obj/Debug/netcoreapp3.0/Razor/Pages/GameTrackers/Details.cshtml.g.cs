#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "163b10dd7660d07986287673b4c94efa34df6454"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_GameTrackers_Details), @"mvc.1.0.razor-page", @"/Pages/GameTrackers/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"163b10dd7660d07986287673b4c94efa34df6454", @"/Pages/GameTrackers/Details.cshtml")]
    public class Pages_GameTrackers_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>GameTracker</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#line 15 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GameTracker.Category));

#line default
#line hidden
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#line 18 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Details.cshtml"
       Write(Html.DisplayFor(model => model.GameTracker.Category));

#line default
#line hidden
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-page=\"./Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 472, "\"", 508, 1);
#line 23 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Details.cshtml"
WriteAttributeValue("", 487, Model.GameTracker.ID, 487, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-page=\"./Index\">Back to List</a>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HM.Blazor.Pages.GameTrackers.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HM.Blazor.Pages.GameTrackers.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HM.Blazor.Pages.GameTrackers.DetailsModel>)PageContext?.ViewData;
        public HM.Blazor.Pages.GameTrackers.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
