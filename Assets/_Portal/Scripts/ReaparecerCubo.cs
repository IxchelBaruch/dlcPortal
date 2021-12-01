using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaparecerCubo : MonoBehaviour
{

    public GameObject prefabCubo;
    [Header("Reaparecer")]
    public bool tubo1;
    public bool tubo2;

    public Vector3 tubo1Pos;
    public Vector3 tubo2Pos;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {            
            Reaparecer();
            Destroy(gameObject);
        }
    }

    private void Reaparecer()
    {
        if (tubo1)
        {
            GameObject go = Instantiate(prefabCubo, tubo1Pos, Quaternion.identity);
            go.SetActive(true);
            go.GetComponent<ReaparecerCubo>().enabled = true;
        }
        else if (tubo2)
        {
            GameObject go = Instantiate(prefabCubo, tubo2Pos, Quaternion.identity);
            go.SetActive(true);
            go.GetComponent<ReaparecerCubo>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cubeDestroy"))
        {
            Reaparecer();
            Destroy(gameObject);
        }
    }
}
