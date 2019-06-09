using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public GameObject pivotArm;

    public enum DirectionAttack
    {
        Left, Right
    }

    
    private DirectionAttack directionAttack = DirectionAttack.Right;
    private bool canAttack = false;
    public float targetDistance;
    public float meleDistance;
    public float attackCooldown;
    public int damage;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    override public void Start ()
    {
        base.Start();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

	override public void Update ()
    {
        Movement();
        if (canAttack)
        {
            Attack();
        }

        if (FlipX)
        {
            if (playerReference != null)
            {


                if (playerReference.transform.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }


        if (stats.life < 0)
        {
            Destroy(gameObject);
            Utilities.LoadScene("Win");
        }
    }

 
    override public void Movement()
    {
        if (playerReference != null)
        {
            if (Vector3.Distance(transform.position, playerReference.transform.position) < targetDistance)
            {

                if (Vector3.Distance(transform.position, playerReference.transform.position) < meleDistance )
                {

                    if (!canAttack)
                    {
                        canAttack = true;
                        if (transform.position.x < playerReference.gameObject.transform.position.x)
                        {
                            directionAttack = DirectionAttack.Right;
                            animator.SetTrigger("AttackRight");

                        }
                        if (transform.position.x > playerReference.gameObject.transform.position.x)
                        {
                            directionAttack = DirectionAttack.Left;
                            animator.SetTrigger("AttackLeft");

                        }
                    }
                }
                else
                {
                    if (!canAttack)
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
        canAttack = false;
    }

    public override void Attack()
    {
        if (directionAttack == DirectionAttack.Left)
        {
            Invoke("CanAttackReseter", 1.5f);
        }
        if (directionAttack == DirectionAttack.Right)
        {
            Invoke("CanAttackReseter", 1.5f);
        }
    }

   
}
