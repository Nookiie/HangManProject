using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HM.Blazor.Services
{
    public class AppState
    {

        // Actual state
        public IReadOnlyList<Word> SearchResults { get; private set; }

        public bool SearchInProgress { get; private set; }

        private readonly List<Word> list = new List<Word>();

        public IReadOnlyList<Word> List => list;

        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;

        // Receive 'http' instance from DI
        private readonly HttpClient http;
        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public void AddToList(Word word)
        {
            list.Add(word);
            NotifyStateChanged();
        }

        public void RemoveFromList(Word word)
        {
            list.Remove(word);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

