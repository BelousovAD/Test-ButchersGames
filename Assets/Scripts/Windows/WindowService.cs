using System;
using System.Collections.Generic;

namespace Windows
{
    internal class WindowService : IWindowService
    {
        private const int MinCountToClose = 0;

        private readonly IWindowSpawner _spawner;
        private readonly Stack<Window> _windowsHistory = new ();
        private readonly Dictionary<string, Window> _spawnedWindows = new ();

        public WindowService(IWindowSpawner spawner) =>
            _spawner = spawner;

        public void CloseCurrent()
        {
            if (_windowsHistory.Count <= 0)
            {
                return;
            }
            
            Window window = _windowsHistory.Pop();
            window.SetInteractable(false);
            window.SetActive(false);

            if (_windowsHistory.Count <= 0)
            {
                return;
            }
            
            window = _windowsHistory.Peek();
            window.SetActive(true);
            window.SetInteractable(true);
        }

        public void Open(string id, int countToClose)
        {
            if (countToClose < MinCountToClose)
            {
                throw new ArgumentOutOfRangeException(nameof(countToClose), countToClose, null);
            }

            Window lastWindow;

            if (_windowsHistory.Count > 0)
            {
                lastWindow = _windowsHistory.Peek();
                lastWindow.SetInteractable(false);
            }

            for (int i = 0; i < countToClose; i++)
            {
                if (_windowsHistory.Count > 0)
                {
                    lastWindow = _windowsHistory.Pop();
                    lastWindow.SetActive(false);
                }
            }

            if (_spawnedWindows.TryGetValue(id, out Window window) == false)
            {
                window = _spawner.Spawn(id);
                _spawnedWindows.Add(id, window);
            }

            _windowsHistory.Push(window);
            window.SetActive(true);
            window.SetInteractable(true);
        }
    }
}