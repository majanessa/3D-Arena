using Mechanics;

namespace Model
{
    [System.Serializable]
    public class FlyEnemyModel
    {
        public float hp = 50;
        
        public float attack = 25;
        
        public FlyEnemyController flyEnemyController;
    }
}