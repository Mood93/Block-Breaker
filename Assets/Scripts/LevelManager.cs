﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        Brick.breakableCount = 0;
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);

    }

    void Start() {

    }

    public void QuitRequest() {
        Debug.Log("Quit level request");
        Application.Quit();
    }

    public void LoadNextLevel () {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
