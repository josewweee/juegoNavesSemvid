using UnityEngine;
using System.Collections;

public class TeleportWhenLimit : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "TopLimit")
        {
            transform.position = new Vector3(transform.position.x, -11.86f, transform.position.z);
        }
        
        if(coll.gameObject.tag == "BottomLimit")
        {
            transform.position = new Vector3(transform.position.x, -3.85f, transform.position.z);
        }
    }
}
