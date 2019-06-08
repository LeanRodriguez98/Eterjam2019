using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public enum Direction
    {
        Left,
        Right
    }

    public float speed;
    public int damage;
    [HideInInspector]
    public Direction direction = Direction.Right;
	void Start () {
        Destroy(gameObject, 2.0f);
	}
	
	void Update () {
        if (direction == Direction.Right)
        {
            transform.position += gameObject.transform.right * speed * Time.deltaTime;
        }
        else if (direction == Direction.Left)
        {
            transform.position -= gameObject.transform.right * speed * Time.deltaTime;
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().SetDamage(damage);
            Destroy(gameObject);
        }
    }


}
