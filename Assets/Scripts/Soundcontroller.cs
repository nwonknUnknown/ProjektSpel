using UnityEngine;

[RequireComponent(typeof(AudioSource))]

//Simon Voss
//Enables to play or pause audio by calling methods from other scripts

public class Soundcontroller : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.Play(0);
    }

    public void PauseSound()
    {
        audioSource.Pause();
    }
}