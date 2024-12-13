using Game.Gameplay.Cards;
using Game.Gameplay.Levels;
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
        [SerializeField] private CardBundlesCollection _cardBundles;
        [SerializeField] private LevelsCollection _levels;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent<CardsGridView>(_cardsGrid);
            builder.RegisterComponent<LevelGoalView>(_levelGoalView);
            
            builder.Register<CardFactory>(Lifetime.Singleton)
                .WithParameter(_cardPrefab);
            
            builder.RegisterInstance<CardBundlesCollection>(_cardBundles);
            builder.RegisterInstance<LevelsCollection>(_levels);
            
            builder.Register<CardBundleGenerator>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<GameLevelState>(Lifetime.Singleton).AsSelf();
            builder.RegisterEntryPoint<LevelPresenter>(Lifetime.Singleton).AsSelf();
        }
    }
}