namespace Model.Enemy
{
    [System.Serializable]
    public class FlyEnemyModel : IEnemyModel
    {
        public int Damage => 15;
        public int PowerForPlayer => 15;
    }
}
