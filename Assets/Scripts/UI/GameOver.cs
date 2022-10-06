using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        public Camera cam, playerCam;
        public GameObject gameOverPanel;

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void SetActive()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameOverPanel.SetActive(true);
            playerCam.gameObject.SetActive(false);
            cam.gameObject.SetActive(true);
        }
    }
}