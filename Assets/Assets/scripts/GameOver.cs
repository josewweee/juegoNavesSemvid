using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    float TimeToDestroy = 0f;
    bool AudioTime = false;
    public AudioClip SonidoFinDelJuego;

	//REFERENCE VARIABLE
	public GameObject Ref;
	private float MyScore;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (AudioTime == true) {
            TimeToDestroy += Time.deltaTime;
            if (TimeToDestroy > 0.5f) {
				Destroy2();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Asteroid")
        {
            GetComponent<AudioSource>().clip = SonidoFinDelJuego;
            GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            AudioTime = true;
        }
    }

    void Destroy2()
    {
		MyScore = Ref.GetComponent<Score> ().score;
		if(MyScore > PlayerPrefs.GetFloat("HighScore")){
			PlayerPrefs.SetFloat ("HighScore", MyScore);
		}
        Destroy(this.gameObject);
        Application.LoadLevel("Inicio");
    }
}
