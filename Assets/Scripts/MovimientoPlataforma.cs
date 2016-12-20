using UnityEngine;
using System.Collections;

public class MovimientoPlataforma : MonoBehaviour {
    public GameObject plataforma;
    public Transform inicio;
    public Transform fin;
    public float velocidad = 10f;

    private Vector3 destino;

	// Use this for initialization
	void Start () {
        destino = fin.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, destino, velocidad * Time.deltaTime);

        if (plataforma.transform.position == fin.position) {
            destino = inicio.position;
       }
        if (plataforma.transform.position == inicio.position) {
            destino = fin.position;
        }
	
	}
}
