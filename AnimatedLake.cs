using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedLake : MonoBehaviour
{

    public float speedX;
    public float speedY;
    private float curveX;
    private float curveY;


    // Start is called before the first frame update
    void Start()
    {
        curveX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curveX = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curveX += Time.deltaTime * speedX;
        curveY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curveX, curveY));


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        JogadorMovimento jo = GetComponent<JogadorMovimento>();
    //        jo.Death();
    //    }
    //}
}
