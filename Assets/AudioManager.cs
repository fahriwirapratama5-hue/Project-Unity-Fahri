using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource bgmSource; // AudioSource khusus BGM

    [Header("BGM Clip")]
    [SerializeField] private AudioClip backgroundMusic; // File musik latar

    private void Awake()
    {
        // Sistem Singleton + DontDestroyOnLoad
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Menjaga AudioManager tetap hidup saat pindah scene
        }
        else
        {
            Destroy(gameObject); // Menghancurkan duplikat jika kembali ke scene awal
            return;
        }
    }

    private void Start()
    {
        // Memutar musik latar otomatis saat game dimulai
        if (backgroundMusic != null)
        {
            PlayBGM(backgroundMusic);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource != null && clip != null)
        {
            bgmSource.clip = clip;
            bgmSource.loop = true; // Mengaktifkan musik berulang (loop)
            bgmSource.Play();
        }
    }
}