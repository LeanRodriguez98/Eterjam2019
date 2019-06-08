using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Enemy {

    public float targetDistance;
    public float meleDistance;
    public int damage;
    private bool canAttack = true;
    public float attackCooldown;

    // Use this for initialization
    public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();
        Movement();
	}

    public void Movement()
    {
        if (playerReference != null)
        {
                if (Vector3.Distance(transform.position, playerReference.transform.position) < targetDistance)
                {
                    if (Vector3.Distance(transform.position, playerReference.transform.position) < meleDistance)
                    {
                        if (canAttack)
                        {
                            Atack();
                            canAttack = false;
                            Invoke("CanAttackReseter", attackCooldown);
                        }
                    }
                    else
                    {
                        if (transform.position.x > playerReference.gameObject.transform.position.x)
                        {
                            gameObject.transform.position -= transform.right * stats.speedMovement * Time.deltaTime;
                        }
                        if (transform.position.x < playerReference.gameObject.transform.position.x)
                        {
                            gameObject.transform.position += transform.right * stats.speedMovement * Time.deltaTime;
                        }
                    }
                }
        }
    }

    public void CanAttackReseter()
    {
        canAttack = true;
    }

    public override void Atack()
    {
        playerReference.SetDamage(damage);
    }

  
   

}
