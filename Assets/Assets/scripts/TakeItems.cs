using UnityEngine;
using System.Collections;

public class TakeItems : MonoBehaviour {

    //audio variables
    public AudioClip CoinsClip;
    public AudioClip AmmoClip;
    public AudioClip BoostClip;

    //reference variables
    public bool HavingAmmo = false;
    public bool HavingCoins = false;
    public bool HavingBoost = false;
	public bool HavingDoubleBoost = false;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    //sets
    public void setAmmo(bool value)
    {
        HavingAmmo = value;
    }

    public void setCoins(bool value)
    {
        HavingCoins = value;
    }

    public void setBoost(bool value)
    {
        HavingBoost = value;
    }

	public void setDoubleBoost(bool value)
	{
		HavingDoubleBoost = value;
	}
		

    void OnCollisionEnter2D(Collision2D coll)
    {
        //hiting a coin
        if (coll.gameObject.tag == "Coins")
        {
            GetComponent<AudioSource>().clip = CoinsClip;
            GetComponent<AudioSource>().Play();
            HavingCoins = true;
            Destroy(coll.gameObject);
        }

        //hiting an ammo box
        if(coll.gameObject.tag == "Ammo")
        {
            GetComponent<AudioSource>().clip = AmmoClip;
            GetComponent<AudioSource>().Play();
            HavingAmmo = true;
            Destroy(coll.gameObject);
        }
			
        //hiting a boost
		if (coll.gameObject.tag == "Boost") {
			

			if (HavingBoost == true) {
				GetComponent<AudioSource> ().clip = BoostClip;
				GetComponent<AudioSource> ().Play ();
				HavingDoubleBoost = true;
				//HavingBoost = false;
				Destroy (coll.gameObject);
			}else{
				GetComponent<AudioSource> ().clip = BoostClip;
				GetComponent<AudioSource> ().Play ();
				HavingBoost = true;
				//HavingDoubleBoost = false;
				Destroy (coll.gameObject);
			}
        }
    }
}
