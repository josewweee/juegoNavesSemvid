using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    //variables de velocidad
    public float speed = 5.0F; //esta es la velocidad usada en el movimiento mas controlado
    public float movimiento = 0.7f;

    //objetos que seran modificados
    public Rigidbody2D thisBody;

    void Start () {
        thisBody = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        //MOVIMIENTO PC
            //MOVIMIENTO CON FISICA
                /*if (Input.GetButton("Vertical"))
                {
                    thisBody.AddForce(new Vector2(0, Input.GetAxis("Vertical") * movimiento), ForceMode2D.Impulse);
                }*/

                /*if (Input.GetKey(KeyCode.S))
                {
                    thisBody.AddForce(new Vector2(0, -movimiento), ForceMode2D.Impulse);
                }*/


            //MOVIMIENTO SIN FISICA
                //transform.Translate(0, Input.GetAxis("Vertical") * 5.0f * Time.deltaTime, 0);

        //MOVIMIENTO ANDROID
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.gameObject.tag == "PadUp")
                    {
                        Debug.DrawLine(ray.origin, hit.point);
                        OnMouseDownUp();
                    }
                    if (hit.collider.gameObject.tag == "PadDown")
                    {
                        OnMouseDownDown();
                    }
                }
            }

    }


    void OnMouseDownDown()
    {
        transform.Translate(0, -1 * 5.0f * Time.deltaTime, 0);
        //thisBody.AddForce(new Vector2(0, 1 * -movimiento), ForceMode2D.Impulse);
    }


    void OnMouseDownUp()
    {
        transform.Translate(0, 1 * 5.0f * Time.deltaTime, 0);
        //thisBody.AddForce(new Vector2(0, 1 * movimiento), ForceMode2D.Impulse);
    }
}
