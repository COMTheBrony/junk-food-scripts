using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUpgrade : MonoBehaviour
{
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            source.Play();
            JogadorStats level = other.GetComponent<JogadorStats>();
            level.playerLevel += 1;
            Destroy(gameObject);
        }
    }
}
