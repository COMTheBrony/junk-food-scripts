using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuniçãoTela : MonoBehaviour
{
    public float ammoOnClip;
    public float ammoReserve;
    public bool isFiring;
    public Text ammoOnClipDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(ammoOnClip == 0)
            ammoOnClip = 15;
        if (ammoReserve == 0)
            ammoReserve = 15;

    }

    // Update is called once per frame
    void Update()
    {
        ammoOnClipDisplay.text = ammoOnClip.ToString() + " / " + ammoReserve.ToString();
    }
}
