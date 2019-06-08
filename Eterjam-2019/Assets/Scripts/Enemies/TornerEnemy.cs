using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornerEnemy : Enemy {

    public GameObject bullet;

    override public void Start () {
        base.Start();
	}
	
	override public void Update () {
        base.Update();
	}

    public void Attack()
    {
        
        Instantiate(bullet, transform.position, transform.rotation);
    }

}
