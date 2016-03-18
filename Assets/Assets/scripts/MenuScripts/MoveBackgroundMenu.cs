using UnityEngine;
using System.Collections;

public class MoveBackgroundMenu : MonoBehaviour {
    //variable de velocidad
    private float speed = 0.3f;

    void Start()
    {

    }


    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0);
    }
}
