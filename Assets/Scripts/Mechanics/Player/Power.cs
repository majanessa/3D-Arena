using Core;
using Mechanics.Enemy;
using Model;
using UI;
using UnityEngine;

namespace Mechanics.Player
{
    public class Power : MonoBehaviour
    {
        public RectTransform powerBar;
        
        public FixedButton ultaButton;
        
        [HideInInspector]
        public float currentPower;
        
        private readonly PlayerModel _model = Simulation.GetModel<PlayerModel>();
        
        private GameObject[] _enemies;

        private void Start()
        {
            powerBar.offsetMax = new Vector2(-1f * 200f * (_model.maxPower - _model.power) / 100f, 0);
        }

        private void Update()
        {
            Ulta();
        }

        public void AddPower(int power)
        {
            currentPower += power;
            if (currentPower >= _model.maxPower)
                currentPower = _model.maxPower;
            powerBar.offsetMax = new Vector2(200f * (-_model.maxPower + currentPower) / 100f, 0);
        }

        private void Ulta()
        {
            if (currentPower >= _model.maxPower)
            {
                ultaButton.gameObject.SetActive(true);
                if (ultaButton.pressed)
                {
                    _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        ReactiveTarget.OnSpawn(_enemies[i]);
                    }
                    powerBar.offsetMax = new Vector2(200f * (-_model.maxPower - _model.maxPower) / 100f, 0);
                    currentPower = 0;
                }
            }
        }
    }
}
