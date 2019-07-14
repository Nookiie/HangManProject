#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "820def1ecf64ec41b2d62dbb7f42dd1bb2f5d519"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace HM.Blazor.Pages
{
    #line hidden
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
using System;

#line default
#line hidden
#line 3 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using System.Collections.Generic;

#line default
#line hidden
#line 4 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using System.Linq;

#line default
#line hidden
#line 5 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using System.Text;

#line default
#line hidden
#line 6 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using System.IO;

#line default
#line hidden
#line 7 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HangmanLogic.Logic;

#line default
#line hidden
#line 8 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Entities.GameItems;

#line default
#line hidden
#line 9 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Entities.Difficulty;

#line default
#line hidden
#line 10 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Entities.GameCondition;

#line default
#line hidden
#line 11 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Abstraction;

#line default
#line hidden
#line 12 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/game")]
    public class Game : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 32 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
       
    bool gameStarted = false;

    int wordCount = 0;

    GameData gameData = new GameData();

    public static void StartGame(string category, GameDifficulty GameDifficulty)
    {
        List<Word> words = new List<Word>
    {
                new Word("apple"),
                new Word("stuff"),
                new Word("elephant"),
                new Word("archipelago"),
                new Word("imagination")
            };

        IGameData gameData = new GameData(category, words, GameDifficulty);
        gameData.CheckWordsForErrors();

        Word chosenWord = gameData.GetRandomWord();
        Word printWord = new Word();
        printWord.Name = chosenWord.Name;

        printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_ ");
        while (true)
        {
            // GameLogic.PrintGameData(printWord, gameData);

            char input = Console.ReadKey().KeyChar;

            if (input == '!')
            {
                if (gameData.GetJokerCount() > 0)
                    input = GameLogic.GetJoker(gameData, chosenWord, printWord);
                else
                    continue;
            }

            if (gameData.GuessCharacterInWord(input, chosenWord) && !printWord.Name.Contains(input))
            {
                if (gameData.Win(chosenWord))
                {
                    GameLogic.GameOver(chosenWord, gameData, GameCondition.Won);
                    break;
                }
                else
                {
                    for (int i = 0; i < chosenWord.Name.Length; i++)
                    {
                        if (chosenWord.Name[i] == input)
                        {
                            StringBuilder sb = new StringBuilder(printWord.Name);
                            sb[i] = input;
                            printWord.Name = sb.ToString();
                        }
                    }
                    continue;
                }
            }
            else if (!gameData.GuessCharacterInWord(input, chosenWord))
            {
                if (gameData.Fail())
                {
                    GameLogic.GameOver(chosenWord, gameData, GameCondition.Lost);
                    break;
                }
                else
                {
                    continue;
                }
            }

        }
    }


#line default
#line hidden
    }
}
#pragma warning restore 1591
