using UnityEngine;
using System.Collections;

public class MoveAsteroid : MonoBehaviour {

    //gameObject to work on
    public GameObject Asteroid;
    private Rigidbody2D thisBody;

    //speed variables
    private float velocidad = -18f;

    //reference variables
    private GameObject jugador;

    //time variables
    public float boostTime = 0.0f;
	public float DoubleboostTime = 0.0f;

    void Start () {
        jugador = GameObject.FindGameObjectWithTag("Player");
        thisBody = Asteroid.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        SpeedBoost();
		DoubleSpeedBoost ();
        //thisBody.AddForce(new Vector2(velocidad,0), ForceMode2D.Impulse);
        transform.Translate(velocidad * Time.deltaTime, 0, 0);
    }
    
    void SpeedBoost()
    {
		if(jugador.GetComponent<TakeItems>().HavingBoost == true && jugador.GetComponent<TakeItems>().HavingDoubleBoost == false)
        {
            if (boostTime < 5.0f) {
                velocidad = -23f;
                boostTime +=Time.deltaTime;
			}if (boostTime > 4.9f){
                boostTime = 0f;
                velocidad = -18f;
                //jugador.GetComponent<TakeItems>().setBoost(false);
            }
        }
    }

	void DoubleSpeedBoost()
	{
		if(jugador.GetComponent<TakeItems>().HavingDoubleBoost == true)
		{
			boostTime = 0f;
			if (DoubleboostTime < 5.0f) {
				velocidad = -28f;
				DoubleboostTime +=Time.deltaTime;
			}if (DoubleboostTime > 4.9f){
				DoubleboostTime = 0f;
				velocidad = -18f;
				//jugador.GetComponent<TakeItems>().setBoost(false);
			}
		}
	}
		
}
