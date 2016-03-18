using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    //score variable
    public float score = 0.0f;
    private int scoreInt;
	private float HighScore;

    //reference variables
    private GameObject reference;
    public TextMesh marcador;
	public TextMesh maxScore;

	//time variables
	private float BoostTime = 0.0f;
	private float DoubleBoostTime = 0.0f;

	//gui variables
	public GameObject Score3x;
	public GameObject Score6x;

	void Start () {
        reference = this.gameObject;
		HighScore = PlayerPrefs.GetFloat ("HighScore");
		maxScore.text = HighScore.ToString ("f0");
	}

	void Update () {
        ActualizarScore();
        score += Time.deltaTime;
        PlusScore();
		tripleScore ();
		SixScore ();
	}

    void PlusScore()
    {
        if (reference.GetComponent<TakeItems>().HavingCoins == true)
        {
            score += 10f;
            reference.GetComponent<TakeItems>().setCoins(false);
        }
    }

	void tripleScore()
	{
		if (reference.GetComponent<TakeItems>().HavingBoost == true)
		{
			if (BoostTime < 5.0f) {
				score += Time.deltaTime * 3;
				BoostTime += Time.deltaTime;
				Score3x.GetComponent<MeshRenderer> ().enabled = true;
			} if(BoostTime > 4.9f) {
				reference.GetComponent<TakeItems>().setBoost(false);
				Score3x.GetComponent<MeshRenderer>().enabled = false;
				BoostTime = 0.0f;
			}
		}
	}

	void SixScore()
	{
		if (reference.GetComponent<TakeItems>().HavingDoubleBoost == true)
		{
			Score3x.GetComponent<MeshRenderer>().enabled = false;
			if (DoubleBoostTime < 5.0f) {
				score += Time.deltaTime * 3;
				DoubleBoostTime += Time.deltaTime;
				Score6x.GetComponent<MeshRenderer> ().enabled = true;
			} if(DoubleBoostTime > 4.9f) {
				reference.GetComponent<TakeItems>().setDoubleBoost(false);
				Score6x.GetComponent<MeshRenderer>().enabled = false;
				DoubleBoostTime = 0.0f;
			}
		}
	}
		
    void ActualizarScore()
    {
        marcador.text = score.ToString("f0");
    }
}
