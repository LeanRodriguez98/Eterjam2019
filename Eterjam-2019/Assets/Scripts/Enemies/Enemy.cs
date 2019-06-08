using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [System.Serializable]
    public struct Stats
    {
        public int life;
        public int damageResistance;
        public int speedMovement;
    }

    public Stats stats;

    public void Start()
    {
        if (stats.damageResistance < 0)
        {
            stats.damageResistance = 0;
            Debug.LogWarning(gameObject.name + " Error. Damage resistance can't be less at 0");
        }
    }

    private void Update()
    {
        if (stats.life < 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetDamage(int damage)
    {
        stats.life -= (damage - stats.damageResistance);
    }

    
}
