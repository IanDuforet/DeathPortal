using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region SINGLETON
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if(_instance == null && !_applicationQuitting)
            {
                //find it in case it was placed in the scene
                if(_instance == null)
                {
                    //none was found in the scene, create a new instance
                    GameObject newObject = new GameObject("Singleton_SoundManager");
                    _instance = newObject.AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
    }
    private static bool _applicationQuitting = false;
    public void OnApplicationQuit()
    {
        _applicationQuitting = true;
    }

    private void Awake()
    {
        //we want this object to persist when a scene changes
        DontDestroyOnLoad(gameObject);
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public AudioClip[] _jumpSounds;
    public AudioClip[] _deathSounds;
    public AudioClip[] _teleportSounds;
    public AudioClip _highlightSound;
    public AudioClip _buttonPressSound;
    public AudioClip _jumppadSound;
    public AudioClip _goalSound;
    public AudioClip _explosionSound;
    public AudioClip _respawnSound;
    public float _effectVolume = 1;

    public enum Sounds
    {
        Jump,
        Death,
        Teleport,
        Highlight,
        ButtonPress,
        Jumppad,
        Goal,
        BulletExplosion,
        Respawn
    }


    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = this.GetComponent<AudioSource>();
        _source.Play();
    }

    public void PlaySound(Sounds sound)
    {
        switch(sound)
        {
            case Sounds.Jump:
                JumpSound();
                break;
            case Sounds.Death:
                DeathSound();
                break;
            case Sounds.Teleport:
                TeleportSound();
                break;
            case Sounds.Highlight:
                HighlightSound();
                break;
            case Sounds.ButtonPress:
                ButtonPressSound();
                break;
            case Sounds.Jumppad:
                JumppadSound();
                break;
            case Sounds.Goal:
                GoalSound();
                break;
            case Sounds.BulletExplosion:
                ExplosionSound();
                break;
            case Sounds.Respawn:
                RespawnSound();
                break;
        }
    }

    void JumpSound()
    {
        int randomIndex = Random.Range(0, 2);
        _source.PlayOneShot(_jumpSounds[randomIndex], _effectVolume);
    }

    void DeathSound()
    {
        int randomIndex = Random.Range(0, 2);
        _source.PlayOneShot(_deathSounds[randomIndex], _effectVolume);
    }

    void TeleportSound()
    {
        int randomIndex = Random.Range(0, 2);
        _source.PlayOneShot(_teleportSounds[randomIndex], _effectVolume);
    }
    void HighlightSound()
    {
        _source.PlayOneShot(_highlightSound, _effectVolume);
    }
    void ButtonPressSound()
    {
        _source.PlayOneShot(_buttonPressSound, _effectVolume);
    }
    void JumppadSound()
    {
        _source.PlayOneShot(_jumppadSound, _effectVolume);
    }
    void GoalSound()
    {
        _source.PlayOneShot(_goalSound, _effectVolume);
    }
    void ExplosionSound()
    {
        _source.PlayOneShot(_explosionSound, _effectVolume);
    }
    void RespawnSound()
    {
        _source.PlayOneShot(_respawnSound, _effectVolume);
    }
}
