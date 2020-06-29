using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriarPersonagem.Habilidades
{

    public abstract class Habilidade : MonoBehaviour
    {        
        public abstract IEnumerator Cast();
    }
}
