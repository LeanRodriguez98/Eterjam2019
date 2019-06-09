using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyParticleEffect : MonoBehaviour {

    public GameObject particleGameObject;

    private void Awake()
    {
        if (particleGameObject.GetComponent<ParticleSystem>()) {
            Debug.LogWarning("El GameObject Asignado no contiene un Particle System");
        }
    }

    private void OnDestroy()
    {
        Instantiate(particleGameObject, gameObject.transform.position, gameObject.transform.rotation);
    }
}
