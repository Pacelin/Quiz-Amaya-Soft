namespace Game.Gameplay.Cards
{
    public interface ICardBundleGenerator
    {
        CardData[] Generate(int count, out int goalIndex);
    }
}