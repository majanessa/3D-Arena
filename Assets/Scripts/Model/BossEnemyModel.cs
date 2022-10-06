using Mechanics;

namespace Model
{
    [System.Serializable]
    public class BossEnemyModel
    {
        public int hp = 100;

        public int damage = 25;

        public int powerForPlayer = 50;
        
        public BossEnemyController bossEnemy;
    }
}