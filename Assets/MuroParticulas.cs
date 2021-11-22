using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroParticulas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Suelo") && !other.gameObject.CompareTag("Pared"))
        {
            Destroy(other.gameObject);
        }
    }
}
