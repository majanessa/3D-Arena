using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        public GameObject[] panels;

        private void SetActivePanel(int index)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var active = i == index;
                var g = panels[i];
                if (g.activeSelf != active) g.SetActive(active);
            }
        }
        
        public void OnPausePanel()
        {
            SetActivePanel(0);
        }
        
        public void UnPausePanel()
        {
           panels[0].SetActive(false);
        }
        
        public void OnGameOverPanel()
        {
            SetActivePanel(1);
        }
    }
}