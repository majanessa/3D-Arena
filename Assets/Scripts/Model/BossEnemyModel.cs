using Mechanics;

namespace Model
{
    [System.Serializable]
    public class BossEnemyModel
    {
        public float hp = 100;

        public float attack = 25;
        
        public BossEnemyController bossEnemy;
    }
}