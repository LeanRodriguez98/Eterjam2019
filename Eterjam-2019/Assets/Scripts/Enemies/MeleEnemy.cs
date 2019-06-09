using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Enemy {

    public float targetDistance;
    public float meleDistance;
    public int damage;
    private bool canAttack = true;
    public float attackCooldown;
    private Rigidbody2D rigidbody2d;
    // Use this for initialization
    public override void Start () {
        base.Start();
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();
        Movement();
	}

     override public void Movement()
    {
        if (playerReference != null)
        {
            if (rigidbody2d.velocity.y == 0)
            {

                if (Vector3.Distance(transform.position, playerReference.transform.position) < targetDistance)
                {
                    if (Vector3.Distance(transform.position, playerReference.transform.position) < meleDistance)
                    {
                        if (canAttack)
                        {
                            Attack();
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
    }

    public void CanAttackReseter()
    {
        canAttack = true;
    }

    public override void Attack()
    {
        playerReference.SetDamage(damage);
    }

  
   

}
