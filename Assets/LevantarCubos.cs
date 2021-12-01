using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarCubos : MonoBehaviour
{
    GameObject cubo;
    public Transform cuboPos;
    bool sosteniendo = false;


    private void Update()
    {
        if(sosteniendo)
        {
            cubo.transform.position = cuboPos.position;
            cubo.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !sosteniendo && cubo != null /*&& cuboPos.childCount <= 0*/)
        {
            //print("activado");
            sosteniendo = true;
            /*cubo.transform.position = cuboPos.position;
            cubo.transform.parent = cuboPos;
            cubo.GetComponent<Rigidbody>().isKinematic = true;*/
        }
        else if(Input.GetKeyDown(KeyCode.E) && sosteniendo/*&& cuboPos.childCount != 0*/)
        {
            //print("desactivado");
            sosteniendo = false;
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            //cubo.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cubo") && cubo == null)
        {
            cubo = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo") && cubo != null && !sosteniendo)
        {
            cubo = null;
        }
    }
}
