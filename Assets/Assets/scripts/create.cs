using UnityEngine;
using System.Collections;

public class create : MonoBehaviour {
    
    //objetos que seran instanciados
    public GameObject Asteroid;
    public GameObject Coins;
    public GameObject Asteroid2;
    public GameObject Ammo;
    public GameObject NOS;

    //posiciones para instanciar objetos
    private Vector3 posicionAsteroid;
    private Vector3 posicionMonedas;
    private Vector3 posicionAmmo;
    private Vector3 posicionNOS;

    //tiempo para instanciar objetos
    private float timeAsteroid = 0.0f;
    private float timeMonedas = 0.0f;
    private float timeAmmo = 0.0f;
    private float timeNOS = 0.0f;
    public float t = 0.6f;
    //variable para cambiar entre sprites
    private bool TypeOfAsteroid = true;

    void Start () {
	
	}

    //metodo para crear asteroides
    void CreateAsteroids()
    {
        if (TypeOfAsteroid == true)
        {
            posicionAsteroid = new Vector3(4.8f, Random.Range(-3.53f, -12.1f), -3f);
            Instantiate(Asteroid, posicionAsteroid, transform.rotation);
            TypeOfAsteroid = false;
        }
        else
        {
            posicionAsteroid = new Vector3(4.8f, Random.Range(-3.53f, -12.1f), -3f);
            Instantiate(Asteroid2, posicionAsteroid, transform.rotation);
            TypeOfAsteroid = true;
        }

    }
    //metodo para crear monedas
    void CreateCoins()
    {
        posicionMonedas = new Vector3(4.8f, Random.Range(-3.53f, -12.1f), -3f);
        Instantiate(Coins, posicionMonedas, transform.rotation);
    }
    //metodo para crear municiones
    void CreateAmmo()
    {
        posicionAmmo = new Vector3(4.8f, Random.Range(-3.53f, -12.1f), -3f);
        Instantiate(Ammo, posicionAmmo, transform.rotation);
    }
    //metodo para crear nitrogeno
    void CreateNOS()
    {
        posicionNOS = new Vector3(4.8f, Random.Range(-3.53f, -12.1f), -3f);
        Instantiate(NOS, posicionNOS, transform.rotation);
    }
	void Update () {
        //tiempos de creacion
        timeAsteroid += Time.deltaTime;
        
        if (timeAsteroid > t)
        {
            CreateAsteroids();
            timeAsteroid = 0.0f;
            if (t > 0.3f)
            {
                t -= 0.001f;
            }

        }

        timeMonedas += Time.deltaTime;
        if (timeMonedas > 1f)
        {
            CreateCoins();
            timeMonedas = 0.0f;
        }

        timeAmmo += Time.deltaTime;
        if (timeAmmo > 5f)
        {
            CreateAmmo();
            timeAmmo = 0.0f;
        }

        timeNOS += Time.deltaTime;
        if (timeNOS > 2f)
        {
            CreateNOS();
            timeNOS = 0.0f;
        }
    }
}
