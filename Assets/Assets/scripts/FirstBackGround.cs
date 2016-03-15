using UnityEngine;
using System.Collections;

public class FirstBackGround : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < -52.2)
        {
            Destroy(this.gameObject);
        }
	}
}
