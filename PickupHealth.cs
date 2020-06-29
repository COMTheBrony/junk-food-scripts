using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public JogadorStats stats;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {            
            if (stats.currentHealth < 100)
            {
                source.Play();
                stats.HealDamage(25);
                Destroy(gameObject);
            }
        }
    }
}
