namespace Model
{
    [System.Serializable]
    public class FlyEnemyModel : IEnemyModel
    {
        public int hp = 50;
        
        public int Damage => 15;
        
        public int PowerForPlayer => 15;
        
        //public FlyEnemyController flyEnemyController;
    }
}