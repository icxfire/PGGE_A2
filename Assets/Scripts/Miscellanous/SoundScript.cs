using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] clip;
    private bool playOnStart = false;
    public static SoundScript instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    
    public void OnClick_Single()
    {
        audio.PlayOneShot(clip[0]);
    }

    public void OnClick_Multi()
    {
        audio.PlayOneShot(clip[1]);
    }

    public void OnClick_Join()
    {
        audio.PlayOneShot(clip[2]);
    }

    public void OnClick_Back()
    {
        audio.PlayOneShot(clip[3]);
    } 
}
