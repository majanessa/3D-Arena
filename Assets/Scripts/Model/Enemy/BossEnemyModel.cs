namespace Model.Enemy
{
    [System.Serializable]
    public class BossEnemyModel : IEnemyModel
    {
        public int Damage => 25;
        public int PowerForPlayer => 50;
        public float Speed => 0.5f;
    }
}
