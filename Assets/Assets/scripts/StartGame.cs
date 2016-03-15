using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    //tiempo para empezar el juego
    float timeLeft = 0f;
    bool CargarTiempo = false;

    void Start () {
        
    }
	
	void Update () {
        if(CargarTiempo == true)
        {
            timeLeft += Time.deltaTime;
            if (timeLeft > 1.5f)
            {
                Application.LoadLevel("Game");
            }
        }
        
    }

    //al clickear el boton
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        CargarTiempo = true;

    }
}
