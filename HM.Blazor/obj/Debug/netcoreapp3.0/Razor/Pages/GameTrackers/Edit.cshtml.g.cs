#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62f4c7d6a7d6492e43101084c21726dd6d586806"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_GameTrackers_Edit), @"mvc.1.0.razor-page", @"/Pages/GameTrackers/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62f4c7d6a7d6492e43101084c21726dd6d586806", @"/Pages/GameTrackers/Edit.cshtml")]
    public class Pages_GameTrackers_Edit : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            WriteLiteral(@"
<h1>Edit</h1>

<h4>GameTracker</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form method=""post"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""GameTracker.Category"" class=""control-label""></label>
                <input asp-for=""GameTracker.Category"" class=""form-control"" />
                <span asp-validation-for=""GameTracker.Category"" class=""text-danger""></span>
            </div>
            <input type=""hidden"" asp-for=""GameTracker.ID"" />
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-page=""./Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#line 34 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\GameTrackers\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HM.Blazor.Pages.GameTrackers.EditModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HM.Blazor.Pages.GameTrackers.EditModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HM.Blazor.Pages.GameTrackers.EditModel>)PageContext?.ViewData;
        public HM.Blazor.Pages.GameTrackers.EditModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
