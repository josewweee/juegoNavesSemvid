using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
    //variable de velocidad
    private float speed = 1f;
    private float BoosTime = 0f;
	private float DoubleboostTime = 0.0f;

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
		if(jugador.GetComponent<TakeItems>().HavingBoost == true && jugador.GetComponent<TakeItems>().HavingDoubleBoost == false)
        {
            if (BoosTime < 5.0f) {
                speed = 1.7f;
                BoosTime += Time.deltaTime;
            }
			if(BoosTime > 4.9f)
            {
                BoosTime = 0f;
                speed = 1f;
                //jugador.GetComponent<TakeItems>().setBoost(false);
            }
        }
    }

	void DoubleSpeedBoost()
	{
		if(jugador.GetComponent<TakeItems>().HavingDoubleBoost == true)
		{
			BoosTime = 0.0f;
			if (DoubleboostTime < 5.0f) {
				speed = 2.4f;
				DoubleboostTime +=Time.deltaTime;
			}if (DoubleboostTime > 4.9f){
				DoubleboostTime = 0f;
				speed = 1f;
				//jugador.GetComponent<TakeItems>().setBoost(false);
			}
		}
	}
}
