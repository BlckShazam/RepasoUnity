using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float velocidad = 5f;
    public float fuerza = 1f;
    public float Salto = 300f;

    private bool suelo_cerca = false;
    private Rigidbody2D rb;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (Input.GetKey(KeyCode.RightArrow)) {
            movimientoDerecha();
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            movimientoIzquierda();
        }

        if (Input.GetKey(KeyCode.Space) && suelo_cerca) {
            saltar();
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

    void saltar() {
        rb.AddForce(new Vector2(0, Salto));
        animator.SetBool("Jump", true);
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

   void OnTriggerEnter2D(Collider2D objeto){
        if (objeto.tag == "Suelo") {
            suelo_cerca = true;
            animator.SetBool("Jump", false);
        }

    } 

}
