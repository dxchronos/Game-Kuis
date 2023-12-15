using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private AudioSource _bgmPrefab = null;

    [SerializeField] private AudioSource _sfxPrefab = null;

    [SerializeField] private AudioClip[] _bgmClips = new AudioClip[0];

    private AudioSource _bgm = null;

    private AudioSource _sfx = null;

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.Log("Objek \"AudioManager\" sudah ada .\n" + "Hapus Objek serupa.", instance);
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
       
        _bgm = Instantiate(_bgmPrefab);
        DontDestroyOnLoad(_bgm);

        _sfx  = Instantiate(_sfxPrefab);
        DontDestroyOnLoad(_sfx);
    }

    private void OnDestroy() 
    {
        if  (this == instance)
        {
            instance = null;
            if (_bgm != null)
            Destroy(_bgm.gameObject);
        }
    }

    public void PlayBGM(int index)
    {
        if (_bgm.clip == _bgmClips[index])
        return;

        _bgm.clip = _bgmClips[index];
        _bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfx.PlayOneShot(clip);
    }
}
