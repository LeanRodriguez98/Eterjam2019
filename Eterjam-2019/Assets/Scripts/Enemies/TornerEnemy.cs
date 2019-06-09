using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornerEnemy : Enemy {

    public GameObject bullet;
    public float targerDistance;
    public float shootDelay = 2.5f;
    override public void Start () {
        base.Start();
        Attack();
    }
	
	override public void Update () {
        base.Update();
	}

    override public void Attack()
    {
        if (playerReference != null)
        {

            if (Vector3.Distance(transform.position, playerReference.transform.position) < targerDistance)
            {
                Instantiate(bullet, transform.position, transform.rotation).GetComponent<EnemyBullet>().shootIt = true;
            }
            Invoke("Attack", shootDelay);
        }

    }

}
