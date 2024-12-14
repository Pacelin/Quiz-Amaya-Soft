using System;
using Game.Gameplay.Levels;
using VContainer.Unity;

namespace Game.UI
{
    public class LevelFinishUIPresenter : IInitializable, IDisposable
    {
        private readonly GameLevelState _levelState;
        private readonly LevelFinishUI _restartUI;
        private readonly LoadingScreen _loadingScreen;
        
        public LevelFinishUIPresenter(GameLevelState levelState, LevelFinishUI restartUI,
            LoadingScreen loadingScreen)
        {
            _levelState = levelState;
            _restartUI = restartUI;
            _loadingScreen = loadingScreen;
        }
        
        public void Initialize()
        {
            _restartUI.gameObject.SetActive(false);
            _restartUI.OnRestartClicked += OnRestartClicked;
            _levelState.OnFinish += OnFinishLevel;
        }

        public void Dispose()
        {
            _restartUI.OnRestartClicked -= OnRestartClicked;
            _levelState.OnFinish -= OnFinishLevel;
        }
        
        private void OnFinishLevel()
        {
            _restartUI.ShowingEffect.Prepare();
            _restartUI.gameObject.SetActive(true);
            _restartUI.ShowingEffect.Play();
        }

        private void OnRestartClicked()
        {
            _loadingScreen.Show(
                () =>
                {
                    _levelState.Reset();
                    _restartUI.gameObject.SetActive(false);
                },
                () => _levelState.Start());
        }
    }
}