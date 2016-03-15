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
    void Start () {
        jugador = GameObject.FindGameObjectWithTag("Player");
        thisBody = Asteroid.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        SpeedBoost();
        //thisBody.AddForce(new Vector2(velocidad,0), ForceMode2D.Impulse);
        transform.Translate(velocidad * Time.deltaTime, 0, 0);
    }
    
    void SpeedBoost()
    {
        if(jugador.GetComponent<TakeItems>().HavingBoost == true)
        {
            if (boostTime < 5.0f) {
                velocidad = -23f;
                boostTime +=Time.deltaTime;
            }else{
                boostTime = 0f;
                velocidad = -18f;
                jugador.GetComponent<TakeItems>().setBoost(false);
            }
        }
    }
}
