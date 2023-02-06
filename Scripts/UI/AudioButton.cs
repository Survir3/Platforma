using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void SetAudioPlaing()
    {
        if(_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        }
    }
}
