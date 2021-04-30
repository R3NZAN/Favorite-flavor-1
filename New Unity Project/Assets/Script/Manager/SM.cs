using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM : MonoBehaviour
{
    public static SM sm;

    public AudioSource[] AS; // 0.BGM , 1.BGS , 2.SEç

    public Animator anim;

    void Awake()
    {
        if (sm == null)
        {
            DontDestroyOnLoad(gameObject);
            sm = this;
        }
        else if (sm != this)
        {
            Destroy(gameObject);
        }
    }

    public void Voz (AudioClip voz)
    {
        AS[2].PlayOneShot(voz);
    }

    // Play Backgrund Music
    public void PlayBGM(AudioClip _clip)
    {
        AS[0].clip = _clip;
        AS[0].Play();
    }

    // Play Background Sounds
    public void PlayBGS(AudioClip _clip, bool _loop)
    {
        AS[1].clip = _clip;
        AS[1].loop = _loop ? true : false;
        AS[1].Play();
    }
    public void PlayOneShotBGS(AudioClip _clip)
    {
        AS[1].PlayOneShot(_clip);
    }

    // Play Sound Effects
    public void PlayOneShotSE(AudioClip clip)
    {
        AS[2].PlayOneShot(clip);
    }
    public void PlaySE(AudioClip _clip)
    {
        AS[2].clip = _clip;
        AS[2].Play();
    }
}
