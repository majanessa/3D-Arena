using Mechanics;

namespace Model
{
    [System.Serializable]
    public class FlyEnemyModel
    {
        public int hp = 50;
        
        public int damage = 15;
        
        public int powerForPlayer = 15;
        
        public FlyEnemyController flyEnemyController;
    }
}