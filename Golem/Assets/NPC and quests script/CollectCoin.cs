namespace NPC_and_quests_script
{
    public class CollectCoin
    {
        public delegate void EnemyEventHandler(Coin coin);

        public static event EnemyEventHandler OnCoinCollected;

        public static void CoinCollected(Coin coin)
        {
            if (OnCoinCollected != null)
            {
                OnCoinCollected(coin);
            }
        }
    }
}