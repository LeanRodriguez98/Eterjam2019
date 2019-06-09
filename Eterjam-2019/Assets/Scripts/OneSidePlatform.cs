using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidePlatform : MonoBehaviour {
    private Player playerReference;
    private BoxCollider2D boxCollider2D;
    
	// Use this for initialization
	void Start () {
        playerReference = Player.playerInstance;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (playerReference != null)
        {
            if (playerReference.transform.position.y - (playerReference.transform.localScale.y / 2) > transform.position.y)
            {
                boxCollider2D.enabled = true;
            }
            else
            {
                boxCollider2D.enabled = false;
            }
        }
    }
}
