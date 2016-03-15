using UnityEngine;
using System.Collections;

public class ZonaDeDisparo : MonoBehaviour {

    //objects to create
    public GameObject Bullet;
    //time variables
    private float TimeForShooting = 0f;
    public int bullets = 10;

    //reference variables
    public GameObject reference;
    public TextMesh ammunition;

	void Start () {
        reference.GetComponent<TakeItems>();
	}

	void Update () {
        TimeForShooting += Time.deltaTime;
        UpdateAmmo();
        //shoot function
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "PadFire" && TimeForShooting > 0.5f && bullets > 0)
                {
                    Fire();
                }
            }
        }
        //geting ammofunction
        recharge();
	}

    void recharge()
    {
        if (reference.GetComponent<TakeItems>().HavingAmmo == true)
        {
            bullets += 10;
            reference.GetComponent<TakeItems>().setAmmo(false);
        }
    }

    void UpdateAmmo()
    {
        ammunition.text = bullets.ToString();
    }

    void Fire()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        TimeForShooting = 0f;
        bullets--;
        GetComponent<AudioSource>().Play();
    }
}
