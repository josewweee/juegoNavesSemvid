using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
    //variable de velocidad
    private float speed = 1f;
    private float BoosTime = 0f;

    //variable de referencia
    private GameObject jugador;

	void Start () {
        jugador = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
        SpeedBoost();
        //transform.Translate(speed * Time.deltaTime, 0, 0);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed)%1, 0);
    }

    //boost funciton
    void SpeedBoost()
    {
        if(jugador.GetComponent<TakeItems>().HavingBoost == true)
        {
            if (BoosTime < 5.0f) {
                speed = 1.7f;
                BoosTime += Time.deltaTime;
            }
            else
            {
                BoosTime = 0f;
                speed = 1f;
                jugador.GetComponent<TakeItems>().setBoost(false);
            }
        }
    }
}
