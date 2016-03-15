using UnityEngine;
using System.Collections;

public class GoCredits : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    //al clickear el boton
    void OnMouseDown()
    {
        Application.LoadLevel("Credits");

    }
}
