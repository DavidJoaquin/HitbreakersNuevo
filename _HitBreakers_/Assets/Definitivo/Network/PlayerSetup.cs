using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera camaraEscena;

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            for(int i = 0; i< componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }

        }
        else
        {
            camaraEscena = Camera.main;
            if (camaraEscena != null)
            {
                camaraEscena.gameObject.SetActive(false);
            }
            
        }
	}

    private void OnDisable()
    {
        if (camaraEscena != null)
        {
            camaraEscena.gameObject.SetActive(true);
        }
    }


}
