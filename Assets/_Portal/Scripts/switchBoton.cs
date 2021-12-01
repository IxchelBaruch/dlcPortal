using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBoton : MonoBehaviour
{

    public Transform cubito;
    public Transform positionSpawn;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                cubito.position = positionSpawn.position;
            }

        }
    }
}
