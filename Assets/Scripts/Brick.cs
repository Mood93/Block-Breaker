using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit2D(Collision2D coll) {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            HandleHits();
        }
        
    }

    void HandleHits () {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else {
            LoadSprites();
        }
    }

    void LoadSprites () {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO Remove this method once we can actually win
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }

}
