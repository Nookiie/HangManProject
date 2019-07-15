#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9efccf2ae557fbabf19c9ed673f7cfe7716cd9c5"
// <auto-generated/>
#pragma warning disable 1591
namespace HM.Blazor.Pages.Accounts
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
#line 1 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor"
using Components;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/accounts/register")]
    public class Register : UserManager
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.AddMarkupContent(0, "<h3>Register</h3>\r\n\r\n");
            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "row");
            builder.AddMarkupContent(3, "\r\n    ");
            builder.OpenElement(4, "div");
            builder.AddAttribute(5, "class", "col-sm-auto col-md-5 col-lg-5 ");
            builder.AddMarkupContent(6, "\r\n        ");
            builder.OpenElement(7, "div");
            builder.AddAttribute(8, "class", "form-group");
            builder.AddMarkupContent(9, "\r\n            ");
            builder.AddMarkupContent(10, "<label for=\"username\">Username</label>\r\n            ");
            builder.OpenElement(11, "input");
            builder.AddAttribute(12, "type", "text");
            builder.AddAttribute(13, "id", "username");
            builder.AddAttribute(14, "class", "form-control");
            builder.AddAttribute(15, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(
#line 11 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor"
                                                                          Username

#line default
#line hidden
            ));
            builder.AddAttribute(16, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Username = __value, Username));
            builder.CloseElement();
            builder.AddMarkupContent(17, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(18, "\r\n\r\n        ");
            builder.OpenElement(19, "div");
            builder.AddAttribute(20, "class", "form-group");
            builder.AddMarkupContent(21, "\r\n            ");
            builder.AddMarkupContent(22, "<label for=\"password\">Password</label>\r\n            ");
            builder.OpenElement(23, "input");
            builder.AddAttribute(24, "type", "password");
            builder.AddAttribute(25, "id", "password");
            builder.AddAttribute(26, "class", "form-control");
            builder.AddAttribute(27, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(
#line 16 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor"
                                                                              Password

#line default
#line hidden
            ));
            builder.AddAttribute(28, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Password = __value, Password));
            builder.CloseElement();
            builder.AddMarkupContent(29, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(30, "\r\n\r\n        ");
            builder.OpenElement(31, "div");
            builder.AddAttribute(32, "class", "form-group");
            builder.AddMarkupContent(33, "\r\n            ");
            builder.AddMarkupContent(34, "<label for=\"password\">Email</label>\r\n            ");
            builder.OpenElement(35, "input");
            builder.AddAttribute(36, "type", "password");
            builder.AddAttribute(37, "id", "password");
            builder.AddAttribute(38, "class", "form-control");
            builder.AddAttribute(39, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(
#line 21 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor"
                                                                              Email

#line default
#line hidden
            ));
            builder.AddAttribute(40, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Email = __value, Email));
            builder.CloseElement();
            builder.AddMarkupContent(41, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(42, "\r\n\r\n        ");
            builder.OpenElement(43, "div");
            builder.AddAttribute(44, "class", "form-group");
            builder.AddMarkupContent(45, "\r\n            ");
            builder.OpenElement(46, "button");
            builder.AddAttribute(47, "class", "btn btn-primary");
            builder.AddAttribute(48, "onClick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 25 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Accounts\Register.razor"
                                                       RegisterUser

#line default
#line hidden
            ));
            builder.AddContent(49, "Register");
            builder.CloseElement();
            builder.AddMarkupContent(50, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(51, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(52, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
