using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
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
    
    public void OnClick()
    {
        audio.PlayOneShot(clip);
    }
}
