using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    Animator anim;

    public GameObject btn1, btn2, btn3;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Abrir()
    {
        anim.SetBool("Abierto", true);
    }

    public void Cerrar()
    {
        anim.SetBool("Abierto", false);
    }

    private void Update()
    {


        if (btn1.GetComponentInChildren<Boton>().botonActivado && btn2.GetComponentInChildren<Boton>().botonActivado && btn3.GetComponentInChildren<Boton>().botonActivado)
        {
            Abrir();
        }
        else {
            Cerrar();
        
        }
    }
}
