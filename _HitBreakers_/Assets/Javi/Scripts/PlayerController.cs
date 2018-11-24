using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //velocidad base de movimiento
    public float velocidad;
    //el parámetro del player
    private Rigidbody player;
    //dirección de movimento
    private Vector3 inputMovimiento;
    //velocidad hacia la dirección de movimiento
    private Vector3 velocidadMovimiento;
    //la cámara que usaremos para apuntar
    private Camera mainCamera;
    Vector3 apuntar;

    public Vector3 posRaycast;



    // Use this for initialization
    void Start () {
        //asignamos el player al Rigidbody que hemos definido (solo hay uno por ahora, habrá que ver como lo hacemos luego con los items)
        player = GetComponent<Rigidbody>();
        //lo mismo con la cámara, tendremos que usar tags o algo luego para definir la que queremos
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //recogemos si se pulsa el eje de horizontal y el de vertical que definimos en la configuración del juego
        inputMovimiento = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        //definimos que se mueva en esa dirección con la velocidad base
        velocidadMovimiento = inputMovimiento * velocidad;
        //creamos un puntero que sale de la camará hacia la posición del ratón


        Ray punteroCamara = mainCamera.ScreenPointToRay(Input.mousePosition);
        //recogemos donde está la superficie, habrá que actualizarlo luego?
        Plane superficie = new Plane(Vector3.up, Vector3.zero);
        //creamos un parámetro para la longitud que tendrá el raycast desde la cámara al suelo
        float longitudPuntero;

         // Si hay puntero disponible, es decir, que apunta dentro del suelo
        if (superficie.Raycast(punteroCamara, out longitudPuntero)) {
            // creamos un vector3 que coge la posición del puntero
            apuntar = punteroCamara.GetPoint(longitudPuntero);
            // con esto hacemos que el puntero sea visible en el modo debug, para controlar que funciona bien
            Debug.DrawLine(punteroCamara.origin, apuntar, Color.blue);
            // aquí hacemos que el player mire hacía el puntero, pero al forzar el eje y a la posicion del jugador, mirará siempre
            //recto en esa dirección
            posRaycast = new Vector3(apuntar.x, transform.position.y, apuntar.z);

            transform.LookAt(posRaycast);
        }

        if (Input.GetButton("Habilidad1"))
        {
          
        }

    }
    private void FixedUpdate()
    {
        //le decimos que la velocidad del player actualize su posición
        player.velocity = velocidadMovimiento;
    }
    public Vector3 getApuntar() {
        return apuntar;
    }

}
