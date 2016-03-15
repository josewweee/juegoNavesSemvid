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

	void Start () {
        reference = this.gameObject;
		HighScore = PlayerPrefs.GetFloat ("HighScore");
		maxScore.text = HighScore.ToString ("f0");
	}

	void Update () {
        ActualizarScore();
        score += Time.deltaTime;
        PlusScore();
	}

    void PlusScore()
    {
        if (reference.GetComponent<TakeItems>().HavingCoins == true)
        {
            score += 10f;
            reference.GetComponent<TakeItems>().setCoins(false);
        }
    }

    void ActualizarScore()
    {
        marcador.text = score.ToString("f0");
    }
}
