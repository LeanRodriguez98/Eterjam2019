using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArm : MonoBehaviour {

    private Player playerReference;
    private Boss boss;
    private void Start()
    {
        playerReference = Player.playerInstance;
        boss = GetComponentInParent<Boss>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerReference != null)
        {
            if (collision.gameObject == playerReference.gameObject)
            {
                playerReference.SetDamage(boss.damage);
            }
        }
    }
}
