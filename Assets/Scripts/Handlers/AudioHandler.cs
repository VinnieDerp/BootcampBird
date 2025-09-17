using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]    private AudioSource _musicSource;
    [SerializeField]    private AudioSource _SFXSource;

    public AudioClip background;
    public AudioClip gameOver;
    public AudioClip birdFlap;
    public AudioClip scoreUp;
    public AudioClip highScoreUp;
    public AudioClip applaud;

    void Start()
    {
        _musicSource.clip = background;
        _musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        _SFXSource.pitch = Random.Range(0.9f, 1.15f);
        _SFXSource.PlayOneShot(clip);
    }
}
