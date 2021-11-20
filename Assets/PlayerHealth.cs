using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDano(int _dano)
    {
        vidaActual -= _dano;

        print("Me dierooooooooooooooooooooooooooon");

        if(vidaActual <= 0)
        {
            print("Te moriste amigo");
        }
    }
}
