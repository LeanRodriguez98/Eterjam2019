using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour {


    public GameObject objectToTeleport;
    public Transform teleportPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objectToTeleport)
        {
            objectToTeleport.transform.position = teleportPosition.position;
        }
    }
}
