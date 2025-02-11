using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public AudioSource src;
    public AudioClip deathSound;
    void Start() 
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy") || other.CompareTag("NPC"))
        {
  
            src.PlayOneShot(deathSound);
            Destroy(other.gameObject);
        }
    }
}
