using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    protected static MusicManager instance;
    public static MusicManager Instance => instance;

    public AudioClip musicBg;
    public AudioClip musicClick;
    public AudioClip musicWinGame;

    public AudioSource audioSource;
    public AudioSource audioSource1;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    protected virtual void Start()
    {
        this.PlayBackgroundMusic();
    }
    public void PlayBackgroundMusic()
    {
        if (!GameManager.Instance.IsSoundBg) return;
        audioSource.clip = musicBg;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void ToggleMusicBg()
    {
        if (!GameManager.Instance.IsSoundBg)
        {
            audioSource.clip = musicBg;
            audioSource.loop = true;
            audioSource.Stop(); 
        }
        else
        {
            audioSource.clip = musicBg;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlayClickMusic()
    {
        Debug.Log("vao");
        if (!GameManager.Instance.IsSound) return;
        Debug.Log("chay");
        audioSource1.PlayOneShot(musicClick);
    }
    public void PlayWinMusic()
    {
        if (!GameManager.Instance.IsSound) return;
        audioSource1.PlayOneShot(musicWinGame);
    }
}
