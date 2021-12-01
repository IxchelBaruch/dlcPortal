using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    Rigidbody rb;
    Vector3 posicionOriginal;
    bool presionado = false;

    float contador;

    public bool botonActivado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionOriginal = GetComponent<Transform>().position;
    }

    private void Update()
    {
        if(transform.position.y <= -4.0f)
        {
            presionado = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            contador = 0.0f;
            print("enter");
            rb.isKinematic = false;
            botonActivado = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            LeanTween.cancelAll();
            StopAllCoroutines();
            StartCoroutine(Contador());
            if (contador >= 1.0f)
            {
                print("exit");
                rb.isKinematic = true;
                botonActivado = false;
                LeanTween.moveY(gameObject, posicionOriginal.y, 0.5f);
            }
        }
    }

    IEnumerator Contador()
    {
        yield return new WaitForSeconds(1.0f);
        contador = 1.0f;
    }

  
}
