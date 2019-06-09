using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour {


    public GameObject objectToTeleport;
    public Transform teleportPosition;
    public AudioClip audioClip;
    public AudioSource AudioSource;
    public bool changeMusic = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objectToTeleport)
        {
            objectToTeleport.transform.position = teleportPosition.position;
            if (changeMusic)
            {
                AudioSource.clip = audioClip;
                AudioSource.Play();
            }
        }
    }
}
