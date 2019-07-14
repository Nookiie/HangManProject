#pragma checksum "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9662af8e9854d28e6adbe9f935493a011ecde81"
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
#line 13 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Repositories.Abstractions;

#line default
#line hidden
#line 14 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using Repos.Implementations;

#line default
#line hidden
#line 15 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using WebAPI.Controllers;

#line default
#line hidden
#line 16 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
using HM.Data.Context;

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
#line 55 "C:\Users\Nookie\source\repos\Hangman\HM.Blazor\Pages\Game.razor"
       

    #region Variables

    Word printWordDisplay;

    Word chosenWordDisplay;

    string inputDisplay;

    char inputDisplayFirstLetter;

    bool gameInProgress = false;

    bool gameFinished = true;

    bool gameWon = false;

    bool gameLost = false;

    int wordCount = 0;

    int tries = 0;

    int attempts = 0;

    int jokers = MAX_JOKERS;

    int score = 0;

    #endregion

    #region DifficultyValues

    private const int MAX_FAILS = 9;

    private const int DEFAULT_SCORE_MULTIPLIER = 5;

    private const int SCORE_MULTIPLIER_EASY = 5;

    private const int SCORE_MULTIPLIER_NORMAL = 5;

    private const int SCORE_MULTIPLIER_HARD = 5;

    private const int SCORE_MULTIPLIER_INSANE = 5;

    private const int MAX_JOKERS = 1;

    #endregion

    #region Methods

    GameData gameData = new GameData();

    void StartGame()
    {
        List<Word> words = new List<Word>
{
                new Word("apple"),
                new Word("stuff"),
                new Word("elephant"),
                new Word("archipelago"),
                new Word("imagination")
        };

        string category = "Animals";
        IGameData gameData = new GameData(category, words, GameDifficulty.Hard);
        gameData.CheckWordsForErrors();

        Word chosenWord = gameData.GetRandomWord();
        Word printWord = new Word();
        printWord.Name = chosenWord.Name;

        printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_ ");
        printWordDisplay = printWord;
        chosenWordDisplay = chosenWord;
        StartGameFlag(); // Sets up that the game has just started


        /*
        if (inputDisplayFirstLetter == '!')
        {
            if (gameData.GetJokerCount() > 0)
                inputDisplayFirstLetter = GameLogic.GetJoker(gameData, chosenWord, printWord);
            else
                continue;
        }
        */

        /*
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
        */
    }

    void StartGameFlag()
    {
        gameInProgress = true;
    }

    void GetInput()
    {
        if (string.IsNullOrWhiteSpace(inputDisplay))
            return;

        inputDisplayFirstLetter = inputDisplay[0];
    }

    void GuessLetter()
    {
        GetInput();
        bool isGuessed = false;

        if (inputDisplayFirstLetter == '!')
        {
            Joker();
        }

        for (int i = 0; i < chosenWordDisplay.Name.Length; i++)
        {
            if (inputDisplayFirstLetter == chosenWordDisplay.Name[i])
            {
                StringBuilder sb = new StringBuilder(printWordDisplay.Name);
                sb[i] = inputDisplayFirstLetter;
                printWordDisplay.Name = sb.ToString();

                isGuessed = true;
                wordCount++;
            }
        }

        if (!isGuessed)
        {
            tries++;
        }

        if (wordCount == chosenWordDisplay.Name.Length)
        {
            EndGame(GameCondition.Won);
        }

        if (tries == MAX_FAILS)
        {
            EndGame(GameCondition.Lost);
        }
    }

    void EndGame(GameCondition gameCondition)
    {
        gameInProgress = false;
        gameFinished = true;

        if (gameCondition == GameCondition.Won)
        {
            gameWon = true;
            gameLost = false;
        }
        else
        {
            gameLost = true;
            gameWon = false;
        }

        CleanUp();
    }

    void CleanUp()
    {
        chosenWordDisplay = null;
        printWordDisplay = null;
        wordCount = 0;
        tries = 0;
        score = 0;
        jokers = MAX_JOKERS;
    }

    void Joker()
    {
        if (jokers > 0)
        {
            do
            {
                inputDisplayFirstLetter = GetRandomLetterFromWord(chosenWordDisplay);
            }
            while (Regex.Matches(inputDisplayFirstLetter.ToString(), chosenWordDisplay.Name).Count() > 1);

            jokers--;

            GuessLetter();
        }

        else
        {
            return;
        }
    }

    char GetRandomLetterFromWord(Word word)
    {
        Random rnd = new Random();
        int randomIndex = rnd.Next(0, word.Name.Length - 1);
        return word.Name[randomIndex];
    }

    List<Word> GetWordsFromDatabase()
    {
        using (IUnitOfWork unitOfWork = new UnitOfWork())
        {
            return unitOfWork.Words.Get().ToList();
        }
    }

    #endregion

#line default
#line hidden
    }
}
#pragma warning restore 1591
