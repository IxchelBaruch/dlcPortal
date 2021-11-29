using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforms : MonoBehaviour
{

   
    public float movementSpeed;

    [Header("Target")]
    public GameObject[] positionTargets;
    private int indexTarget = 0;
    private Vector3 currentTarget;



    private void OnEnable()
    {
        indexTarget = 0;
    }

    void Update()
    {
        currentTarget = positionTargets[indexTarget].transform.position;

        float stepSpeed = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, stepSpeed);

        if (transform.position == currentTarget)
        {
            indexTarget++;
            if (indexTarget == positionTargets.Length)
            {
                indexTarget = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
