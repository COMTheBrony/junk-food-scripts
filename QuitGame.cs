using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{


    public void QUITARGAME()
    {
        //if (Input.GetKey("escape"))
        Application.Quit();
        Debug.Log("QuitGame");
    }
}
