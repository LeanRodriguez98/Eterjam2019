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
        if (stats.life < 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Atack(){ }

    public void SetDamage(int damage)
    {
        stats.life -= (damage - stats.damageResistance);
    }

    
}
