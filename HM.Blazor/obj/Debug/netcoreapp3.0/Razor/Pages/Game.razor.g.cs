#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52d30990f541e6c15e0b25b06fa2d43691e04030"
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
#line 2 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Entities.GameItems;

#line default
#line hidden
#line 3 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Logic.Logic;

#line default
#line hidden
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Entities.Difficulty;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/game")]
    public class Game : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
  
    if (gameLogic.gameInProgress)
    {

#line default
#line hidden
            builder.AddContent(0, "        ");
            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "col-lg-4");
            builder.AddMarkupContent(3, "\r\n");
#line 9 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
             foreach (var letter in gameLogic.printWordDisplay.Name)
            {

#line default
#line hidden
            builder.AddContent(4, "                ");
            builder.OpenElement(5, "h1");
            builder.AddAttribute(6, "style", "display:inline;");
            builder.AddContent(7, 
#line 11 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                             letter

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(8, "\r\n");
#line 12 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
            }

#line default
#line hidden
            builder.AddContent(9, "        ");
            builder.CloseElement();
            builder.AddMarkupContent(10, "\r\n        ");
            builder.OpenElement(11, "div");
            builder.AddAttribute(12, "class", "row");
            builder.AddAttribute(13, "style", "display:block;");
            builder.AddMarkupContent(14, "\r\n            ");
            builder.OpenElement(15, "div");
            builder.AddAttribute(16, "class", "col-md-6 col-lg-4");
            builder.AddMarkupContent(17, "\r\n                ");
            builder.OpenElement(18, "input");
            builder.AddAttribute(19, "name", "MainCharInput");
            builder.AddAttribute(20, "type", "text");
            builder.AddAttribute(21, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(
#line 16 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                    gameLogic.inputDisplay

#line default
#line hidden
            ));
            builder.AddAttribute(22, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => gameLogic.inputDisplay = __value, gameLogic.inputDisplay));
            builder.CloseElement();
            builder.AddMarkupContent(23, "\r\n                ");
            builder.OpenElement(24, "button");
            builder.AddAttribute(25, "class", "btn btn-primary");
            builder.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 17 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                           gameLogic.GuessLetter

#line default
#line hidden
            ));
            builder.AddContent(27, "Guess");
            builder.CloseElement();
            builder.AddMarkupContent(28, "\r\n\r\n");
#line 19 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                 if (gameLogic.jokers != 0)
                {

#line default
#line hidden
            builder.AddContent(29, "                    ");
            builder.OpenElement(30, "button");
            builder.AddAttribute(31, "class", "btn btn-primary");
            builder.AddAttribute(32, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 21 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                               gameLogic.Joker

#line default
#line hidden
            ));
            builder.AddContent(33, "Use Joker");
            builder.CloseElement();
            builder.AddMarkupContent(34, "\r\n");
#line 22 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                }

#line default
#line hidden
            builder.AddContent(35, "            ");
            builder.CloseElement();
            builder.AddMarkupContent(36, "\r\n            ");
            builder.OpenElement(37, "div");
            builder.AddAttribute(38, "id", "gameData");
            builder.AddAttribute(39, "class", "col-md-6 col-lg-4");
            builder.AddAttribute(40, "style", "font-family:Georgia");
            builder.AddMarkupContent(41, "\r\n                ");
            builder.OpenElement(42, "p");
            builder.AddContent(43, "Words guessed:");
            builder.AddContent(44, 
#line 25 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                  gameLogic.wordCount

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(45, "\r\n                ");
            builder.OpenElement(46, "p");
            builder.AddContent(47, "Number of tries:");
            builder.AddContent(48, 
#line 26 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                    gameLogic.tries

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(49, "\r\n                ");
            builder.OpenElement(50, "p");
            builder.AddContent(51, "Score:");
            builder.AddContent(52, 
#line 27 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                          gameLogic.score

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(53, "\r\n                ");
            builder.OpenElement(54, "p");
            builder.AddContent(55, "Jokers available:");
            builder.AddContent(56, 
#line 28 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                     gameLogic.jokers

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(57, "\r\n                ");
            builder.OpenElement(58, "p");
            builder.AddContent(59, "Input:");
            builder.AddContent(60, 
#line 29 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                          gameLogic.inputDisplayFirstLetter

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(61, "\r\n            ");
            builder.CloseElement();
            builder.AddMarkupContent(62, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(63, "\r\n");
#line 32 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

    else if (!gameLogic.gameInProgress && gameLogic.gameWon)
    {

#line default
#line hidden
            builder.AddContent(64, "        ");
            builder.AddMarkupContent(65, "<h1 style=\"font-family:Georgia;\">You won!</h1>\r\n");
            builder.AddContent(66, "        ");
            builder.OpenElement(67, "button");
            builder.AddAttribute(68, "name", "startBtn");
            builder.AddAttribute(69, "class", "btn btn-primary");
            builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 38 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.StartGame

#line default
#line hidden
            ));
            builder.AddContent(71, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(72, "\r\n");
#line 39 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

    else if (!gameLogic.gameInProgress && gameLogic.gameLost)
    {

#line default
#line hidden
            builder.AddContent(73, "        ");
            builder.AddMarkupContent(74, "<h1 style=\"font-family:Georgia;\">You lost!</h1>\r\n");
            builder.AddContent(75, "        ");
            builder.OpenElement(76, "button");
            builder.AddAttribute(77, "name", "startBtn");
            builder.AddAttribute(78, "class", "btn btn-primary");
            builder.AddAttribute(79, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 45 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.StartGame

#line default
#line hidden
            ));
            builder.AddContent(80, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(81, "\r\n");
#line 46 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }
    else
    {

#line default
#line hidden
            builder.AddContent(82, "        ");
            builder.OpenElement(83, "div");
            builder.AddAttribute(84, "class", "row");
            builder.AddMarkupContent(85, "\r\n            ");
            builder.OpenElement(86, "div");
            builder.AddAttribute(87, "class", "col-md-4 col-lg-6 ");
            builder.AddMarkupContent(88, "\r\n                ");
            builder.OpenElement(89, "div");
            builder.AddAttribute(90, "class", "form-group");
            builder.AddMarkupContent(91, "\r\n                    ");
            builder.AddMarkupContent(92, "<label for=\"sel1\">Difficulty:</label>\r\n                    ");
            builder.OpenElement(93, "select");
            builder.AddAttribute(94, "class", "form-control");
            builder.AddAttribute(95, "id", "difficultySel");
            builder.AddAttribute(96, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIChangeEventArgs>(this, 
#line 53 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                AssignDifficulty

#line default
#line hidden
            ));
            builder.AddMarkupContent(97, "\r\n");
#line 54 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                         foreach (var difficulty in difficulties)
                        {

#line default
#line hidden
            builder.AddContent(98, "                            ");
            builder.OpenElement(99, "option");
            builder.AddAttribute(100, "id", "difficultyDropDown");
            builder.AddAttribute(101, "value", 
#line 56 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                    selectedDifficulty

#line default
#line hidden
            );
            builder.AddContent(102, 
#line 56 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                         difficulty

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(103, "\r\n");
#line 57 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                        }

#line default
#line hidden
            builder.AddContent(104, "                    ");
            builder.CloseElement();
            builder.AddMarkupContent(105, "\r\n                ");
            builder.CloseElement();
            builder.AddMarkupContent(106, "\r\n\r\n                ");
            builder.OpenElement(107, "div");
            builder.AddAttribute(108, "class", "form-group");
            builder.AddMarkupContent(109, "\r\n                    ");
            builder.AddMarkupContent(110, "<label for=\"sel1\">Category:</label>\r\n                    ");
            builder.OpenElement(111, "select");
            builder.AddAttribute(112, "class", "form-control");
            builder.AddAttribute(113, "id", "categorySel");
            builder.AddAttribute(114, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIChangeEventArgs>(this, 
#line 63 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                              AssignCategory

#line default
#line hidden
            ));
            builder.AddMarkupContent(115, "\r\n\r\n");
#line 65 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                         foreach (var item in categories.Select(x => x.Name))
                        {

#line default
#line hidden
            builder.AddContent(116, "                            ");
            builder.OpenElement(117, "option");
            builder.AddAttribute(118, "id", "categoryDropDown");
            builder.AddAttribute(119, "value", 
#line 67 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                  selectedCategory

#line default
#line hidden
            );
            builder.AddContent(120, 
#line 67 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                     item

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(121, "\r\n");
#line 68 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                        }

#line default
#line hidden
            builder.AddContent(122, "                    ");
            builder.CloseElement();
            builder.AddMarkupContent(123, "\r\n                ");
            builder.CloseElement();
            builder.AddMarkupContent(124, "\r\n            ");
            builder.CloseElement();
            builder.AddMarkupContent(125, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(126, "\r\n        ");
            builder.OpenElement(127, "button");
            builder.AddAttribute(128, "name", "startBtn");
            builder.AddAttribute(129, "class", "btn btn-primary");
            builder.AddAttribute(130, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 73 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.StartGame

#line default
#line hidden
            ));
            builder.AddContent(131, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(132, "\r\n");
#line 74 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 76 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
       
    GameLogicBlazor gameLogic = new GameLogicBlazor();

    string selectedCategory;

    string selectedDifficulty;

    List<Category> categories = new List<Category>
{
        new Category("Animals"),
        new Category("Locations"),
        new Category("Programming")
    };

    List<string> difficulties = new List<string>
{
        GameDifficulty.Easy.ToString(),
        GameDifficulty.Normal.ToString(),
        GameDifficulty.Hard.ToString(),
        GameDifficulty.Insane.ToString()
    };

    void AssignDifficulty(UIChangeEventArgs e)
    {
        selectedDifficulty = e.Value.ToString();

        switch (selectedDifficulty)
        {
            case "Easy": gameLogic.gameDifficulty = GameDifficulty.Easy; break;
            case "Normal": gameLogic.gameDifficulty = GameDifficulty.Normal; break;
            case "Hard": gameLogic.gameDifficulty = GameDifficulty.Hard; break;
            case "Insane": gameLogic.gameDifficulty = GameDifficulty.Insane; break;
            default: break;
        }
    }

    void AssignCategory(UIChangeEventArgs e)
    {
        selectedCategory = e.Value.ToString();
        gameLogic.gameCategory = categories.Where(x => x.Name == selectedCategory).FirstOrDefault();
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
