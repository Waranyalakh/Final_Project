using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip Clocktick;
    public AudioClip Allrank;
    public AudioClip Master;
    public AudioClip Aww;
    public AudioClip Pass;
    public AudioClip Cheer;

    // เพลงพื้นหลังสำหรับแต่ละ Scene
    public AudioClip background; // เล่น Scene 0–3
    public AudioClip credit;     // เล่น Scene 6
    public AudioClip ending;     // เล่น Scene 5
    public AudioClip bg1;        // Scene 4 (ฉาก 1)
    public AudioClip bg2;        // Scene 4 (ฉาก 2)
    public AudioClip bg3;        // Scene 4 (ฉาก 3)

    public static AudioManager instance;

    private int previousSceneIndex; // เก็บ Scene ก่อนหน้า

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 0 && currentSceneIndex <= 3)
        {
            PlayBackgroundMusic(background); // เล่นเพลง Scene 0–3
        }

        previousSceneIndex = currentSceneIndex; // บันทึก Scene เริ่มต้น
    }

    // ฟังก์ชันหยุดเพลงพื้นหลัง
    private void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    private void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayCollisionSound()
    {
        if (Pass != null)
        {
            PlaySFX(Pass);
        }
        else
        {
            Debug.LogWarning("Collision sound (Pass) is not assigned!");
        }
    }

    public void PlayTickSound()
    {
        if (Clocktick != null)
        {
            PlaySFX(Clocktick);
        }
        else
        {
            Debug.LogWarning("Clocktick sound (Clocktick) is not assigned!");
        }
    }

    public void PlayMasterSound()
    {
        if (Master != null)
        {
            PlaySFX(Master); // เล่นเสียง Master
        }
        else
        {
            Debug.LogWarning("Master sound (Master) is not assigned!");
        }

        if (Cheer != null)
        {
            PlaySFX(Cheer); // เล่นเสียง Cheer
        }
        else
        {
            Debug.LogWarning("Cheer sound (Cheer) is not assigned!");
        }
    }
    public void PlayRankSound()
    {
        if (Allrank != null)
        {
            PlaySFX(Allrank);
        }
        else
        {
            Debug.LogWarning("Rank sound (rank) is not assigned!");
        }
    }

    public void PlayFailSound()
    {
        if (Aww != null)
        {
            PlaySFX(Aww);
        }
        else
        {
            Debug.LogWarning("Aww sound (fail) is not assigned!");
        }
    }

    private void PlayBackgroundMusic(AudioClip backgroundClip)
    {
        if (backgroundClip != null)
        {
            musicSource.clip = backgroundClip;
            musicSource.volume = 0f;
            musicSource.Play();
            StartCoroutine(FadeInMusic());
        }
        else
        {
            Debug.LogWarning("Background music is not assigned!");
        }
    }

    // Coroutine สำหรับ Fade In
    private IEnumerator FadeInMusic(float fadeDuration = 2f)
    {
        float startVolume = 0f;
        float targetVolume = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, timeElapsed / fadeDuration);
            yield return null;
        }

        musicSource.volume = targetVolume;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if ((previousSceneIndex == 5 || previousSceneIndex == 6) &&
         newSceneIndex != 5 && newSceneIndex != 6)
        {
            StopMusic(); // หยุดเพลงเมื่อออกจาก Scene 5 หรือ 6
        }

        // เล่นเพลงตาม Scene ใหม่
        if (newSceneIndex == 4)
        {
            int selectedStage = DataHandlerSingleton.Instance.selectedStage;
            switch (selectedStage)
            {
                case 1: PlayBackgroundMusic(bg1); break;
                case 2: PlayBackgroundMusic(bg2); break;
                case 3: PlayBackgroundMusic(bg3); break;
                default: Debug.LogWarning("Invalid selectedStage value for Scene 4!"); break;
            }
        }
        else if (newSceneIndex == 5)
        {
            PlayBackgroundMusic(ending);
        }
        else if (newSceneIndex == 6)
        {
            PlayBackgroundMusic(credit);
        }
        // เพิ่มเงื่อนไขสำหรับ Scene 0–3
        else if (newSceneIndex >= 0 && newSceneIndex <= 3)
        {
            // เล่นเพลงพื้นหลังเฉพาะเมื่อ Scene ก่อนหน้าไม่ใช่ 0–3
            if (!(previousSceneIndex >= 0 && previousSceneIndex <= 3))
            {
                PlayBackgroundMusic(background);
            }
        }

        previousSceneIndex = newSceneIndex; // อัปเดต Scene ก่อนหน้า
    }
}