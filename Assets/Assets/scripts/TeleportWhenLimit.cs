using UnityEngine;
using System.Collections;

public class TeleportWhenLimit : MonoBehaviour {

	private GameObject jugador;

	void Start () {
		jugador = this.gameObject;
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "TopLimit")
        {
			jugador.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0f, -1f), ForceMode2D.Impulse);
        }
        
        if(coll.gameObject.tag == "BottomLimit")
        {
			jugador.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0f, 1f), ForceMode2D.Impulse);
        }
    }
}
