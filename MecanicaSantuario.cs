using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaSantuario : MonoBehaviour
{
    [SerializeField] Renderer rend1, rend2, rend3, rend4;

    public GameObject objectE;
    public GameObject particulas;
    public AudioSource activatedSound;

    private bool isActive = false;

    public AbrirPortao portao;

    private void Start()
    {
        objectE.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag =="Player")
        {
            objectE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                
                
                if (isActive == false)
                {
                    Material newMat = Resources.Load("SantuarioAtivado", typeof(Material)) as Material;
                    rend1.material = newMat;
                    rend2.material = newMat;
                    rend3.material = newMat;
                    rend4.material = newMat;


                    portao.santuariosAtivados += 1;
                    //AbrirPortao.santuariosAtivosLista.Add(gameObject.name);
                    isActive = true;
                    

                    GameObject ActivatedGO =  Instantiate(particulas, transform.position, Quaternion.identity);
                    Destroy(ActivatedGO, 4f);
                    activatedSound.Play();
                }
                
            }
        }
    }

    private void Soundd()
    {
        activatedSound = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            objectE.SetActive(false);
    }
    
}
