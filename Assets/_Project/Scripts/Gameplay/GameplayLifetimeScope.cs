using Game.Gameplay.Cards;
using Game.Gameplay.Levels;
using Game.Misc;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private GameObjectGrid _cardsGrid;
        [Space] 
        [SerializeField] private CardBundlesCollection _cardBundles;
        [SerializeField] private LevelsCollection _levels;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CardFactory>(Lifetime.Singleton)
                .WithParameter(_cardPrefab)
                .WithParameter(_cardsGrid.transform);
            builder.RegisterInstance(_cardBundles);
            builder.RegisterInstance(_levels);
            builder.Register<CardBundleGenerator>(Lifetime.Singleton);
        }
    }
}