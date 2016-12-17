using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float velocidad = 5f;
    public float fuerza = 1f;
    public float Salto = 300f;

    private bool suelo_cerca = false;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            movimientoDerecha();
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            movimientoIzquierda();
        }

        if (Input.GetKey(KeyCode.Space) && suelo_cerca) {
            rb.AddForce(new Vector2(0, Salto));
        }
	}

    void movimientoDerecha() {
        rb.velocity = new Vector2(velocidad * fuerza, rb.velocity.y);
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    void movimientoIzquierda() {
        rb.velocity = new Vector2(-velocidad * fuerza, rb.velocity.y);
        this.transform.localScale = new Vector3(-1, 1, 1);
    }
    void OnTriggerStay2D(Collider2D objeto){
        if (objeto.tag == "Suelo") {
            suelo_cerca = true;
        }
    }

    void OnTriggerExit2D(Collider2D objeto){
        if (objeto.tag == "Suelo") {
            suelo_cerca = false;
        }
    }

}
