using Core;
using Model;
using UnityEngine;

namespace Mechanics.Player
{
    public class Health : MonoBehaviour
    {
        public RectTransform healthBar;
        
        [HideInInspector]
        public int currentHealth;
        
        private readonly PlayerModel _model = Simulation.GetModel<PlayerModel>();
        
        public void Hurt(int damage)
        {
            currentHealth -= damage;
            healthBar.offsetMax = new Vector2(-1f * 200f * (_model.hp - currentHealth) / 100f, 0);
            if (currentHealth <= 0)
                GameController.Instance.GameOver();
        }
        
        public void AddHalfHurt()
        {
            healthBar.offsetMax = new Vector2(-1f * 200f * 50f / 100f, 0);
        }

        public void Die()
        {
            
        }
    }
}
