using UnityEngine;
using System.Collections;

using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GameOver : MonoBehaviour {
	//time variables
    float TimeToDestroy = 0f;

	//sound variables (not used anymore)
    bool AudioTime = false;
    public AudioClip SonidoFinDelJuego;

	//reference variables
	public GameObject Ref;

	//score variables
	private float MyScore;

	// google Admob Api variables
	private InterstitialAd interstitial;
	private static string outputMessage = "";

	public static string OutputMessage
	{
		set { outputMessage = value; }
	}

	void Awake(){
		RequestInterstitial ();
	}
	void Start () {
		
	}

	void Update () {
        if (AudioTime == true) {
			Destroy2();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {	//muerte por colicion con asteroide o limites
		if(coll.gameObject.tag == "Asteroid" || coll.gameObject.tag == "TopLimit" || coll.gameObject.tag == "BottomLimit")
        {
            GetComponent<AudioSource>().clip = SonidoFinDelJuego;
            GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            AudioTime = true;
        }
    }

    void Destroy2()
    {	
		//save the max score and destroy the spaceship
		MyScore = Ref.GetComponent<Score> ().score;
		if(MyScore > PlayerPrefs.GetFloat("HighScore")){
			PlayerPrefs.SetFloat ("HighScore", MyScore);
		}
        Destroy(this.gameObject);
        Application.LoadLevel("Inicio");
		ShowInterstitial ();
    }

	/*---------------------------------GOOGLE ADMOB API----------------------------------------------------*/
	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4767223538922579/7810077041";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}

		// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
	}

	private void ShowInterstitial()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			print("Interstitial is not ready yet.");
		}
	}

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args)
		{
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		print("HandleInterstitialLeftApplication event received");
		}

		#endregion
}
