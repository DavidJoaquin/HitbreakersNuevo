using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    //BOOL - Defina cuando se está disparando y cuando no. 
    public bool isFiring;
    //BulletController - El objeto que vamos a disparar, dicho objeto tiene que tener el script BulletController asociado
    public BulletController bullet;
    //FLOAT - La velocidad de la bala
    public float bulletSpeed;
    //FLOAT - El tiempo entre disparos
    public float timeBetweenShots;
    //FLOAT - Un contador que nos permite limitar el tiempo entre dispararos junto a la variable timeBetweenShots
    private float shotCounter;
    //Transform - El objeto de referencia para la posición donde se generan las balas
    public Transform firePoint;
    public float tiempoVidaBala;
    public int dmgBala;


	// Update is called once per frame
	void Update () {

        //Si se pulsa el boton, en este caso el click izquierdo del raton, la variable isFiring pasa a true.
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }

        //Si soltamos el boton, en este caso el click izquierdo del raton, la variable isFiring pasa a false.
        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }


        //Si isFiring es true
        if (isFiring)
        {
            //shotCounter disminuye con el paso del tiempo.
            shotCounter -= Time.deltaTime;
            //Cuando shotCounter llega a 0
            if(shotCounter <= 0)
            {
                //Reiniciamos shotCounter al valor de timeBetweenShots, esto nos permite ajustar el tiempo entre disparos.
                shotCounter = timeBetweenShots;
                //Instanciamos el objeto bala en la posicion del objeto de referencia firePoint, con su posicion y su rotacion.
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                //Asignamos la velocidad a la bala.
                newBullet.speed = bulletSpeed;
                newBullet.tiempoVida = tiempoVidaBala;
                newBullet.dmgBala = dmgBala;
            }
        }
        else
        {
            shotCounter -= Time.deltaTime;
        }
		
	}
}
