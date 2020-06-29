using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LagoRefrigerante : MonoBehaviour
{

    private void OnTriggerStay(Collider other)    
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JogadorStats jog = other.GetComponent<JogadorStats>();
            jog.TakeDamage(1);
            
        }
          
        
        
    }
}
