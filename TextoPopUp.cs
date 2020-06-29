using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoPopUp : MonoBehaviour
{
    public Text texto;
    public RawImage rawImage;
    [SerializeField] public static Text previousText;
    [SerializeField] public static RawImage previousImage;

    void Start()
    {
        previousText = null;
        previousImage = null;
        texto.enabled = false;
        rawImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && texto.enabled == true)
        {
            DesativarTexto();
            DesativarImagem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (previousText != null)
                previousText.enabled = false;
            if (previousImage != null)
                previousImage.enabled = false;
            texto.enabled = true;
            previousText = texto;
            rawImage.enabled = true;
            previousImage = rawImage;
        }
    }

    public void DesativarTexto()
    {
        texto.enabled = false;
    }

    public void DesativarImagem()
    {
        rawImage.enabled = false;
    }

}
