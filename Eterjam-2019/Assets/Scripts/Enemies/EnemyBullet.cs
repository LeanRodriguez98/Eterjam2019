using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;
    public int damage;
    private Player playerReference;
    private Rigidbody2D rigidbody2d;
    // Use this for initialization
    void Start () {
        playerReference = Player.playerInstance;
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce((playerReference.transform.position - transform.position + new Vector3(0,1,0)) * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerReference != null)
        {

            if (collision.gameObject == playerReference.gameObject)
            {
                Destroy(gameObject);
                playerReference.SetDamage(damage);
            }
        }
    }

}
