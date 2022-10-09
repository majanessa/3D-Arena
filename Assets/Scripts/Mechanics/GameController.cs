using Core;
using Mechanics.Enemy;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        
        public UIController ui;
        
        public Camera cam, playerCam;
        
        public bool gameOver = false;

        public bool pause;

        [HideInInspector]
        public bool pauseAxis;

        private void OnEnable()
        {
            Instance = this;
            pause = false;
        }

        private void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Update()
        {
            if (Instance == this) Simulation.Tick();
            if (pauseAxis)
               Pause();
        }
        
        public void GameOver()
        {
            gameOver = true;
            ui.OnGameOverPanel();
            Score.Instance.UpdateBestScoreUI();
            ReactiveTarget.OnSpawn = null;
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
            CursorUnLock();
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
            CursorUnLock();
        }

        public void UnPause()
        {
            ui.UnPausePanel();
            pause = false;
            Time.timeScale = 1;
            playerCam.gameObject.SetActive(true);
            cam.gameObject.SetActive(false);
            CursorLock();
        }

        public void CursorLock()
        {
            if (Application.isEditor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void CursorUnLock()
        {
            if (Application.isEditor)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }
}
