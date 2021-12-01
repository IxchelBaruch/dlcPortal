using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGlass : MonoBehaviour
{
    public GameObject btn;
    public float cantidadMovimiento;

    public bool bottonPisable = true;

    Vector3 targetPos;
    Vector3 originalPos;
    private void Start()
    {
        originalPos = transform.position;
        targetPos = transform.position;
    }

    private void Update()    
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.05f);
        if(bottonPisable)
        {
            if (btn.GetComponentInChildren<Boton>().botonActivado)
            {
                targetPos = originalPos + new Vector3(0, cantidadMovimiento, 0);
            }
            else
            {
                targetPos = originalPos;
            }
        }
        else if(!bottonPisable)
        {
            if (btn.GetComponent<switchBoton>().botonActivado)
            {
                targetPos = originalPos + new Vector3(0, cantidadMovimiento, 0);
            }
            else
            {
                targetPos = originalPos;
            }
        }
    }

}
