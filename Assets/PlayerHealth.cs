using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaActual;
    public Transform respawn;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDano(int _dano)
    {
        vidaActual -= _dano;

        if(vidaActual <= 0)
        {
            gameObject.transform.position = respawn.position;
            vidaActual = vidaMaxima;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor Oil"))
        {
            gameObject.transform.position = respawn.position;
            vidaActual = vidaMaxima;
        }
    }
}
