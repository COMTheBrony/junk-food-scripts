using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistoladinhaAnimações : MonoBehaviour
{
    private Animator anim;
    public MuniçãoTela muni;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PauseMenu.IsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && muni.ammoOnClip != 0)
            {
                anim.CrossFade("Atirar", 0.1f);
                muni.isFiring = true;
                muni.ammoOnClip--;
                muni.isFiring = false;
            }

            if (Input.GetKeyDown(KeyCode.R) && muni.ammoReserve > 0 && muni.ammoOnClip < 15)
            {
                anim.CrossFade("Recarregar", 0.1f);

                float valorAnt = muni.ammoOnClip;
                float valorAdicionar = 15 - valorAnt;

                if (valorAdicionar > muni.ammoReserve)
                    valorAdicionar = muni.ammoReserve;
                
                muni.ammoOnClip += valorAdicionar;
                muni.ammoReserve -= valorAdicionar;                
            }
        }
        else
        {
            return;
        }
    }
}
