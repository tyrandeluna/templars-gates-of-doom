using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    public bool showDeath = true;

    // Update is called once per frame
    void Update () {
		if (Player1.statusDeath && showDeath) {
            GetComponent<ParticleSystem>().Play();
            showDeath = false;
        }
    }
}
