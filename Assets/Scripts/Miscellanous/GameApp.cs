using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using UnityEngine.SceneManagement;

public class GameApp : Singleton<GameApp>
{
    private bool mPause;

    void Start()
    {
        mPause = false;
        InitializeMenu(); // changed function in start to make function clearer
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePauseState();
    }

    void InitializeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void UpdatePauseState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
        }
    }

    public bool GamePaused
    {
        get { return mPause; }
        set
        {
            mPause = value;
            ChangeTimeScale(); // separated the timescale change into a function call to make code more readable
        }
    }
    
    void ChangeTimeScale()
    {
        Time.timeScale = GamePaused ? 0 : 1; // changes the timescale based on the bool value
    }
    
    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded2;
    }

    // called when the game terminates
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded2;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded - Scene Index: " + scene.buildIndex + " Scene Name: " + scene.name);
        //Debug.Log(mode);
    }

    void OnSceneLoaded2(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Hello. Welocome to my scene.");
    }
}
