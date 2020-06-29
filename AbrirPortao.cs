using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AbrirPortao : MonoBehaviour

{
    public GameObject pastel;
    Vector3 posicaoMaxima;
    Vector3 novaPosicao;

    public int santuariosAtivados = 0;

    public int santuariosNaArea;
    public int santuariosNecessarios;


    void Start()
    {
        posicaoMaxima.y = -10;
    }
    
    void Update()
    {
        if (santuariosNaArea > 0)
        {
            if (santuariosAtivados == santuariosNecessarios && novaPosicao.y > posicaoMaxima.y)
            {
                Abrir();
            }
        }  
    }

    public void Abrir()
    {        
        novaPosicao = gameObject.transform.position;
        int i = 0;
        while(i < 20)
        {
            novaPosicao.y -= 0.01f;
            pastel.transform.position = novaPosicao;
            i++;
            if (novaPosicao.y < -3)
                break;
        }
    }
}
