using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public UIController ui;
        
        public bool gameOver = false;

        public bool pause;
        
        public Camera cam, playerCam;

        private void Awake()
        {
            Instance = this;
            pause = false;
        }
        
        public void GameOver()
        {
            gameOver = true;
            //score.UpdateBestScoreUI();
            ui.OnGameOverPanel();
            ReactiveTarget.OnSpawn = null;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            Score.Instance.UpdateBestScoreUI();
        }
        
        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
            gameOver = false;
            pause = false;
        }

        public void Pause()
        {
            ui.OnPausePanel();
            pause = true;
            Time.timeScale = 0;
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        public void UnPause()
        {
            ui.UnPausePanel();
            pause = false;
            Time.timeScale = 1;
            playerCam.gameObject.SetActive(true);
            cam.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}