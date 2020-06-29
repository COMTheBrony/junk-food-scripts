using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMunição : MonoBehaviour
{
    //public GameObject player;
    public MuniçãoTela munição;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
            munição.ammoReserve += 15;
            Destroy(gameObject);
        }
    }
}
