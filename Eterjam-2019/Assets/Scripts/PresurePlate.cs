using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlate : MonoBehaviour {

    private bool canSpawn = true;
    public GameObject enemyToSpawn;
    public Transform[] positionsToSpawnEnemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canSpawn)
            {
                SpawnEnemies();
                canSpawn = false;
            }
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < positionsToSpawnEnemies.Length; i++)
        {
            Instantiate(enemyToSpawn, positionsToSpawnEnemies[i].position, transform.rotation);
        }
    }
}
