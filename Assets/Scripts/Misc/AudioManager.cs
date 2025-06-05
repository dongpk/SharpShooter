using UnityEngine;

public class AudioManager : MonoBehaviour
{
     public static AudioManager Instance { get; private set; }
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
   
    public AudioClip explosion;
    public AudioClip gate;
    public AudioClip takeDamage;
   

    void Awake()
    {
       // Mẫu Singleton để đảm bảo chỉ có một AudioManager tồn tại
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (backgroundMusic) PlayMusic(backgroundMusic, true);
        else Debug.LogWarning("No background music assigned in AudioManager.");
    }
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (!clip) return;
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.ignoreListenerPause = true;   
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip) sfxSource.PlayOneShot(clip);
    }
}
