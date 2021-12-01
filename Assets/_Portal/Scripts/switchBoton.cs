using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBoton : MonoBehaviour
{

    public Transform cubito;
    public Transform positionSpawn;

    public bool botonActivado;
    public bool seDesactiva;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                botonActivado = true;
                //cubito.position = positionSpawn.position;
                if (seDesactiva)
                    botonActivado = false;
            }

        }
    }
}
