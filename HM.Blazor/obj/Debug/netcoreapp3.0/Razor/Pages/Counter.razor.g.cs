#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5115b9628c739e61784a93d50e0dffea5a6e214a"
// <auto-generated/>
#pragma warning disable 1591
namespace HM.Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Layouts;

#line default
#line hidden
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using HM.Blazor;

#line default
#line hidden
#line 7 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\_Imports.razor"
using HM.Blazor.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "p");
            builder.AddContent(1, "Current count: ");
            builder.AddContent(2, 
#line 3 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Counter.razor"
                   currentCount

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(3, "\r\n\r\n");
            builder.OpenElement(4, "button");
            builder.AddAttribute(5, "class", "btn btn-primary");
            builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Counter.razor"
                                           IncrementCount

#line default
#line hidden
            ));
            builder.AddContent(7, "Click me");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 7 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Counter.razor"
       
    int currentCount = 0;

    void IncrementCount()
    {
        currentCount++;
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
