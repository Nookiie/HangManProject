#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d320656a86782a71f434be3d654a850f42aabdb9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace HM.Blazor.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Layouts;

#line default
#line hidden
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using HM.Blazor.Client;

#line default
#line hidden
#line 7 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\_Imports.razor"
using HM.Blazor.Client.Shared;

#line default
#line hidden
#line 1 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\Shared\NavMenu.razor"
using Components;

#line default
#line hidden
    public class NavMenu : LoginManager
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 89 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor.Client\Shared\NavMenu.razor"
       
    bool isLoggedIn = false;

    bool isAdmin = false;

    bool collapseNavMenu = true;

    string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    void ToggleIsAdmin()
    {
        isAdmin = !isAdmin;
    }

    void ToggleIsLoggedIn()
    {
        isLoggedIn = !isLoggedIn;
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
