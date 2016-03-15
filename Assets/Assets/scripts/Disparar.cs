using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {

    public Rigidbody2D thisObject;
    float TimeToDestroy = 0f;
    bool AudioTime = false;
    void Start () {
        thisObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //thisObject.AddForce(new Vector2(5f,0), ForceMode2D.Impulse);
        transform.Translate(25f * Time.deltaTime, 0, 0);
        if (AudioTime == true)
        {
            TimeToDestroy += Time.deltaTime;
            if (TimeToDestroy > 1.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
            GetComponent<AudioSource>().Play();
            AudioTime = true;
            Destroy(coll.gameObject);
            gameObject.GetComponent<Collider2D>().enabled = false;
            //Destroy(this.gameObject);

    }
}
