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
        
        public GameObject ultaButton;

        [HideInInspector]
        public bool powerAxis;
        
        [HideInInspector]
        public float currentPower;

        public ParticleSystem collapse;
        
        private readonly PlayerModel _model = Simulation.GetModel<PlayerModel>();
        
        private GameObject[] _enemies;

        private PlayerController _player;

        private void Start()
        {
            currentPower = _model.power;
            powerBar.offsetMax = new Vector2(-1f * 200f * (_model.maxPower - _model.power) / 100f, 0);
            _player = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (_player.Alive)
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
                ultaButton.SetActive(true);
                if (powerAxis)
                {
                    collapse.Play();
                    _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    if (ReactiveTarget.OnSpawn != null)
                    {
                        for (int i = 0; i < _enemies.Length; i++)
                        {
                            ReactiveTarget.OnSpawn(_enemies[i]);
                            Score.Instance.AddScore(1);
                        }
                    }
                    
                    powerBar.offsetMax = new Vector2(200f * (-_model.maxPower - _model.maxPower) / 100f, 0);
                    currentPower = 0;
                    ultaButton.SetActive(false);
                }
            }
        }
    }
}
