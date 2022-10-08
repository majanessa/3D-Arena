using Mechanics;

namespace Model
{
    [System.Serializable]
    public class BossEnemyModel : IEnemyModel
    {
        public int hp = 100;

        public int Damage => 25;

        public int PowerForPlayer => 50;

        //public BossEnemyController bossEnemy;
    }
}