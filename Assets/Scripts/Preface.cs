using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preface : MonoBehaviour {
    GameObject prefaceGO;
    public RawImage rawImg;


    void Awake()
    {
        prefaceGO = GameObject.Find( "Preface" );
        rawImg = prefaceGO.GetComponent<RawImage>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating( "Fade", 0, 0.002f );
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Fade()
    {
        float delta = 0.005f;

        rawImg.color = Color.Lerp( rawImg.color, Color.clear, delta * (1.001f - rawImg.color.a) );

        if ( rawImg.color.a < 0.1f ) {
            prefaceGO.SetActive( false );
            Destroy( prefaceGO );
        }
        
    }
}
