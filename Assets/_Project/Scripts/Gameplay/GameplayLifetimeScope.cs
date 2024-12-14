using Game.Gameplay.Cards;
using Game.Gameplay.Levels;
using Game.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private LevelGoalView _levelGoalView;
        [SerializeField] private CardsGridView _cardsGrid;
        [Space] 
        [SerializeField] private LevelFinishUI _levelFinishUI;
        [SerializeField] private LoadingScreen _loadingScreen;
        [Space]
        [SerializeField] private CardBundlesCollection _cardBundles;
        [SerializeField] private LevelsCollection _levels;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent<CardsGridView>(_cardsGrid);
            builder.RegisterComponent<LevelGoalView>(_levelGoalView);
            builder.RegisterComponent<LevelFinishUI>(_levelFinishUI);
            builder.RegisterComponent<LoadingScreen>(_loadingScreen);
            
            builder.Register<CardFactory>(Lifetime.Singleton)
                .WithParameter(_cardPrefab);
            
            builder.RegisterInstance<CardBundlesCollection>(_cardBundles);
            builder.RegisterInstance<LevelsCollection>(_levels);
            
            builder.Register<CardBundleGeneratorNoRepeat>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder.RegisterEntryPoint<GameLevelState>(Lifetime.Singleton)
                .AsSelf();
            builder.RegisterEntryPoint<LevelPresenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<LevelFinishUIPresenter>(Lifetime.Singleton);
        }
    }
}