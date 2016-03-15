using UnityEngine;
using System.Collections;

public class destroyer : MonoBehaviour {

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Destroy(coll.gameObject);
        if (coll.gameObject.tag == "Asteroid" || coll.gameObject.tag == "Coins" || coll.gameObject.tag == "Ammo" || coll.gameObject.tag == "Boost")
        {
            Destroy(coll.gameObject);
        }
    }
}
