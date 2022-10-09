using System;
using Gameplay.Player;
using Model;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Player
{
    public class Health : MonoBehaviour
    {
        public RectTransform healthBar;
        
        [HideInInspector]
        public int currentHealth;
        
        private readonly PlayerModel _model = GetModel<PlayerModel>();

        private void Start()
        {
            currentHealth = _model.hp;
        }

        public void Hurt(int damage)
        {
            currentHealth -= damage;
            healthBar.offsetMax = new Vector2(-1f * 200f * (_model.hp - currentHealth) / 100f, 0);
            if (currentHealth <= 0)
                Die();
        }
        
        public void AddHalfHurt()
        {
            healthBar.offsetMax = new Vector2(-1f * 200f * 50f / 100f, 0);
        }

        private void Die()
        {
            var ev = Schedule<PlayerDeath>();
            ev.Player = gameObject.GetComponent<PlayerController>();
        }
    }
}
