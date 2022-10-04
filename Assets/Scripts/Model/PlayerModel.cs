using Mechanics;

namespace Model
{
    [System.Serializable]
    public class PlayerModel
    {
        public float hp = 100;

        public float maxAttack = 100;

        public float attack = 50;

        public float energy = 0;

        public PlayerController player;
    }
}