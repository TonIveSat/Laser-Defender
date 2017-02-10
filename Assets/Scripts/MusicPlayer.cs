using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance;

    public AudioClip StartClip;
    public AudioClip GameClip;
    public AudioClip EndClip;

    private AudioSource musicAudioSource;

    void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            musicAudioSource = GetComponent<AudioSource>();
            musicAudioSource.clip = StartClip;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer level loaded: " + level);
        musicAudioSource.Stop();

        switch (level)
        {
            case 0: musicAudioSource.clip = StartClip; break;
            case 1: musicAudioSource.clip = GameClip; break;
            case 2: musicAudioSource.clip = EndClip; break;
            default:
                break;
        }

        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    void Start()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
