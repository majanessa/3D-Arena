using UnityEngine;

namespace Mechanics
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        
        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.GetString("Play") != "On")
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
                _audioSource.Play();
                PlayerPrefs.SetString("Play", "On");
            }
        }
        
        void Start()
        {
            Application.quitting += () => { OnClear(false); };
            Application.focusChanged += OnClear;
        }

        void OnClear(bool b=false)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
