#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "494ecbf491beb520b49bd1a9cdb06e9838dafdfb"
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
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using ComponentsV2;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/game")]
    public class Game : GameManager
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
#line 8 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
  
    if (gameLogic.gameInProgress)
    {

#line default
#line hidden
            builder.AddContent(0, "        ");
            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "col-lg-4");
            builder.AddMarkupContent(3, "\r\n");
#line 12 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
             foreach (var letter in gameLogic.printWordDisplay.Name)
            {

#line default
#line hidden
            builder.AddContent(4, "                ");
            builder.OpenElement(5, "h1");
            builder.AddAttribute(6, "style", "display:inline;");
            builder.AddContent(7, 
#line 14 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                             letter

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(8, "\r\n");
#line 15 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
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
#line 19 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
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
#line 20 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                           gameLogic.GuessLetter

#line default
#line hidden
            ));
            builder.AddContent(27, "Guess");
            builder.CloseElement();
            builder.AddMarkupContent(28, "\r\n                ");
            builder.OpenElement(29, "div");
            builder.AddAttribute(30, "class", "col-md-3 col-lg-4");
            builder.AddMarkupContent(31, "\r\n");
#line 22 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                     foreach (var letter in letters)
                    {

#line default
#line hidden
            builder.AddContent(32, "                        ");
            builder.OpenElement(33, "button");
            builder.AddAttribute(34, "class", "btn-outline-primary");
            builder.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 24 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                         () => AssignLetter(letter)

#line default
#line hidden
            ));
            builder.AddContent(36, 
#line 24 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                                       letter

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(37, "\r\n");
#line 25 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                    }

#line default
#line hidden
            builder.AddContent(38, "                ");
            builder.CloseElement();
            builder.AddMarkupContent(39, "\r\n");
#line 27 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                 if (gameLogic.jokers != 0)
                {

#line default
#line hidden
            builder.AddContent(40, "                    ");
            builder.OpenElement(41, "button");
            builder.AddAttribute(42, "class", "btn btn-primary");
            builder.AddAttribute(43, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 29 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                               gameLogic.Joker

#line default
#line hidden
            ));
            builder.AddContent(44, "Use Joker");
            builder.CloseElement();
            builder.AddMarkupContent(45, "\r\n");
#line 30 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                }

#line default
#line hidden
            builder.AddContent(46, "            ");
            builder.CloseElement();
            builder.AddMarkupContent(47, "\r\n            ");
            builder.OpenElement(48, "div");
            builder.AddAttribute(49, "id", "gameData");
            builder.AddAttribute(50, "class", "col-md-6 col-lg-4 text-dark");
            builder.AddAttribute(51, "style", "font-family:Georgia");
            builder.AddMarkupContent(52, "\r\n                ");
            builder.OpenElement(53, "p");
            builder.AddContent(54, "Words guessed:");
            builder.AddContent(55, 
#line 33 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                  gameLogic.wordCount

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(56, "\r\n                ");
            builder.OpenElement(57, "p");
            builder.AddContent(58, "Number of tries:");
            builder.AddContent(59, 
#line 34 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                    gameLogic.tries

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(60, "\r\n                ");
            builder.OpenElement(61, "p");
            builder.AddContent(62, "Score:");
            builder.AddContent(63, 
#line 35 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                          gameLogic.score

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(64, "\r\n                ");
            builder.OpenElement(65, "p");
            builder.AddContent(66, "Jokers available:");
            builder.AddContent(67, 
#line 36 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                     gameLogic.jokers

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(68, "\r\n                ");
            builder.OpenElement(69, "p");
            builder.AddContent(70, "Input:");
            builder.AddContent(71, 
#line 37 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                          gameLogic.guessLetter

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(72, "\r\n            ");
            builder.CloseElement();
            builder.AddMarkupContent(73, "\r\n\r\n            ");
            builder.OpenElement(74, "div");
            builder.AddAttribute(75, "id", "gameCheat");
            builder.AddAttribute(76, "class", "col-md-7 text-warning");
            builder.AddMarkupContent(77, "\r\n");
#line 41 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                 if (gameLogic.gameCheatActivated)
                {

#line default
#line hidden
            builder.AddContent(78, "                    ");
            builder.AddMarkupContent(79, "<p>Game Cheat Enabled</p>\r\n                    ");
            builder.OpenElement(80, "p");
            builder.AddContent(81, "Current Word:");
            builder.AddContent(82, 
#line 44 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                     gameLogic.chosenWordDisplay.Name

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(83, "\r\n");
#line 45 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                }
                else
                {

#line default
#line hidden
            builder.AddContent(84, "                    ");
            builder.OpenElement(85, "button");
            builder.AddAttribute(86, "id", "chtToggle");
            builder.AddAttribute(87, "class", "btn btn-primary");
            builder.AddAttribute(88, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 48 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                              gameLogic.CheatToggle

#line default
#line hidden
            ));
            builder.AddContent(89, "Cheat");
            builder.CloseElement();
            builder.AddMarkupContent(90, "\r\n");
#line 49 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                }

#line default
#line hidden
            builder.AddContent(91, "            ");
            builder.CloseElement();
            builder.AddMarkupContent(92, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(93, "\r\n");
#line 52 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

    else if (!gameLogic.gameInProgress && gameLogic.gameWon)
    {

#line default
#line hidden
            builder.AddContent(94, "        ");
            builder.AddMarkupContent(95, "<h1 style=\"font-family:Georgia;\">You won!</h1>\r\n        ");
            builder.OpenElement(96, "button");
            builder.AddAttribute(97, "name", "startBtn");
            builder.AddAttribute(98, "class", "btn btn-primary");
            builder.AddAttribute(99, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 57 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.ResetGame

#line default
#line hidden
            ));
            builder.AddContent(100, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(101, "\r\n");
#line 58 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

    else if (!gameLogic.gameInProgress && gameLogic.gameLost)
    {

#line default
#line hidden
            builder.AddContent(102, "        ");
            builder.AddMarkupContent(103, "<h1 style=\"font-family:Georgia;\">You lost!</h1>\r\n        ");
            builder.OpenElement(104, "button");
            builder.AddAttribute(105, "name", "startBtn");
            builder.AddAttribute(106, "class", "btn btn-primary");
            builder.AddAttribute(107, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 63 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.ResetGame

#line default
#line hidden
            ));
            builder.AddContent(108, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(109, "\r\n");
#line 64 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }
    else
    {

#line default
#line hidden
            builder.AddContent(110, "        ");
            builder.OpenElement(111, "div");
            builder.AddAttribute(112, "class", "row");
            builder.AddMarkupContent(113, "\r\n            ");
            builder.OpenElement(114, "div");
            builder.AddAttribute(115, "class", "col-md-4 col-lg-6 ");
            builder.AddMarkupContent(116, "\r\n                ");
            builder.OpenElement(117, "div");
            builder.AddAttribute(118, "class", "form-group");
            builder.AddMarkupContent(119, "\r\n                    ");
            builder.AddMarkupContent(120, "<label for=\"sel1\">Difficulty:</label>\r\n                    ");
            builder.OpenElement(121, "select");
            builder.AddAttribute(122, "class", "form-control");
            builder.AddAttribute(123, "id", "difficultySel");
            builder.AddAttribute(124, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIChangeEventArgs>(this, 
#line 71 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                AssignDifficulty

#line default
#line hidden
            ));
            builder.AddMarkupContent(125, "\r\n");
#line 72 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                         foreach (var difficulty in Difficulties)
                        {

#line default
#line hidden
            builder.AddContent(126, "                            ");
            builder.OpenElement(127, "option");
            builder.AddAttribute(128, "id", "difficultyDropDown");
            builder.AddAttribute(129, "value", 
#line 74 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                    difficulty

#line default
#line hidden
            );
            builder.AddContent(130, 
#line 74 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                                 difficulty

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(131, "\r\n");
#line 75 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                        }

#line default
#line hidden
            builder.AddContent(132, "                    ");
            builder.CloseElement();
            builder.AddMarkupContent(133, "\r\n                ");
            builder.CloseElement();
            builder.AddMarkupContent(134, "\r\n\r\n                ");
            builder.OpenElement(135, "div");
            builder.AddAttribute(136, "class", "form-group");
            builder.AddMarkupContent(137, "\r\n                    ");
            builder.AddMarkupContent(138, "<label for=\"sel1\">Category:</label>\r\n                    ");
            builder.OpenElement(139, "select");
            builder.AddAttribute(140, "class", "form-control");
            builder.AddAttribute(141, "id", "categorySel");
            builder.AddAttribute(142, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIChangeEventArgs>(this, 
#line 81 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                              AssignCategory

#line default
#line hidden
            ));
            builder.AddMarkupContent(143, "\r\n");
#line 82 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                         foreach (var item in Categories.Select(x => x.Name))
                        {

#line default
#line hidden
            builder.AddContent(144, "                            ");
            builder.OpenElement(145, "option");
            builder.AddAttribute(146, "id", "categoryDropDown");
            builder.AddAttribute(147, "value", 
#line 84 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                  item

#line default
#line hidden
            );
            builder.AddContent(148, 
#line 84 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                         item

#line default
#line hidden
            );
            builder.CloseElement();
            builder.AddMarkupContent(149, "\r\n");
#line 85 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                        }

#line default
#line hidden
            builder.AddContent(150, "                    ");
            builder.CloseElement();
            builder.AddMarkupContent(151, "\r\n                ");
            builder.CloseElement();
            builder.AddMarkupContent(152, "\r\n            ");
            builder.CloseElement();
            builder.AddMarkupContent(153, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(154, "\r\n        ");
            builder.OpenElement(155, "button");
            builder.AddAttribute(156, "name", "startBtn");
            builder.AddAttribute(157, "class", "btn btn-primary");
            builder.AddAttribute(158, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 90 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
                                                                   gameLogic.StartGame

#line default
#line hidden
            ));
            builder.AddContent(159, "New Game");
            builder.CloseElement();
            builder.AddMarkupContent(160, "\r\n");
#line 91 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
    }

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 93 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
       
    GameLogicBlazor gameLogic = new GameLogicBlazor();

    char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };



    string selectedCategory;

    string selectedDifficulty;

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
        gameLogic.gameCategory = Categories.Where(x => x.Name == selectedCategory).FirstOrDefault();
    }

    void AssignLetter(char letter)
    {
        gameLogic.guessLetter = letter;
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
