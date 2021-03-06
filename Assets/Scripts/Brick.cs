﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject smoke;
    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;


    // Use this for initialization
    void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D coll) {
        AudioSource.PlayClipAtPoint(crack, Camera.main.transform.position, 0.5f);
    }

    void OnCollisionExit2D(Collision2D coll) {
        if (isBreakable) {
            HandleHits();
        }
        
    }

    void HandleHits () {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            // Smoke Particles
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
            
        }
        else {
            LoadSprites();
        }
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Sprite Not Found");
        }
    }

    // TODO Remove this method once we can actually win
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }

}
