using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Score : MonoBehaviour
    {
        public static Score Instance { get; private set; }
        
        public Text scoreText;
        public Text bestScoreText;
        
        private int _scoreValue;
        private int _bestScore;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _scoreValue = 0;
            _bestScore = PlayerPrefs.GetInt("BestScore");
            UpdateScoreUI();
            UpdateBestScoreUI();
        }

        public void AddScore(int value)
        {
            _scoreValue += value;
            UpdateScoreUI();
        }

        private void UpdateScoreUI()
        {
            scoreText.text = _scoreValue.ToString();
        }

        public void UpdateBestScoreUI()
        {
            if (_scoreValue > _bestScore)
            {
                _bestScore = _scoreValue;
                PlayerPrefs.SetInt("BestScore", _bestScore);
            }
            bestScoreText.text = "BEST SCORE: " + _bestScore;
        }
    }
}