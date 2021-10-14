using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Endface : MonoBehaviour
{
    private RawImage rawImg;
    private float alpha;
    private float speed = 0.5f;

    void Start()
    {
        StartCoroutine(Fade());
    }

    void Awake()
    {

        rawImg = GetComponent<RawImage>();
    }


    void Update()
    {

    }


    IEnumerator Fade()
    {
        alpha = 0;
        while(alpha < 1)
        {
            alpha += speed * Time.deltaTime;
            var tempColor = rawImg.color;
            tempColor.a = alpha;
            rawImg.color = tempColor;

            yield return new WaitForSeconds(0);
        }

    }

}