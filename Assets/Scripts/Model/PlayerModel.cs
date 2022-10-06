using Mechanics;

namespace Model
{
    [System.Serializable]
    public class PlayerModel
    {
        public int hp = 100;
        
        public int power = 50;

        public int maxPower = 100;
        
        public PlayerController player;
    }
}