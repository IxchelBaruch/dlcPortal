using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBoton2 : MonoBehaviour
{
    public Transform cubito;
    public Transform positionSpawn;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cubito.position = positionSpawn.position;
                cubito.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
    }
}


