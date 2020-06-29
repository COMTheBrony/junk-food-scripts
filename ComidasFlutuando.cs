using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidasFlutuando : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Float");
    }
}
