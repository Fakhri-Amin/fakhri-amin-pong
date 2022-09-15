using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private AudioSource bsAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip whistleSFX;
    [SerializeField] private AudioClip kickSFX;
    [SerializeField] private AudioClip wallSFX;
    [SerializeField] private AudioClip gameEndWhistle;
    [SerializeField] private AudioClip pauseWhistle;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;

        sfxAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        bsAudioSource.ignoreListenerPause = true;
        sfxAudioSource.ignoreListenerPause = true;
    }

    public void PlayWhistleSFX() => sfxAudioSource.PlayOneShot(whistleSFX);
    public void PlayKickSFX() => sfxAudioSource.PlayOneShot(kickSFX);
    public void PlayWallSFX() => sfxAudioSource.PlayOneShot(wallSFX);
    public void PlayGameEndWhistleSFX() => sfxAudioSource.PlayOneShot(gameEndWhistle);
    public void PlayPauseWhistleSFX() => sfxAudioSource.PlayOneShot(pauseWhistle);
    public void TurnTheVolume(float amount) => bsAudioSource.volume = amount;
}
