using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [System.Serializable]
    public struct Stats
    {
        public int life;
        public int damageResistance;
        public float speedMovement;
    }

    public Stats stats;

    protected Player playerReference;

    public SpriteRenderer spriteRenderer;
    public bool FlipX = false;
    public virtual void Start()
    {
        if (stats.damageResistance < 0)
        {
            stats.damageResistance = 0;
            Debug.LogWarning(gameObject.name + " Error. Damage resistance can't be less at 0");
        }

        playerReference = Player.playerInstance;
        
    }

    public virtual void Update()
    {
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
        }
    }

    public virtual void Attack() { }
    public virtual void Movement() { }
    public void SetDamage(int damage)
    {
        stats.life -= (damage - stats.damageResistance);
    }

    
}
