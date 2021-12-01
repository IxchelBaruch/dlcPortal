using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnJugador : MonoBehaviour
{
    public Transform positionSpawn;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor Oil"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = positionSpawn.position;
            }

        }
    }
}
