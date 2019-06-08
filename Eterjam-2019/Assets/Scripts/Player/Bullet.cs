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

}
