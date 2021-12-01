using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeUpright : MonoBehaviour
{
    void FixedUpdate()
    {
        if(transform.rotation.x <= -0.01f || transform.rotation.z <= -0.01f || transform.rotation.x >= 0.01f || transform.rotation.z >= 0.01f)
        {
            /*print("aaaaaaaaaaaaaaaaaaaaaaaaa");
            Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
            */

            LeanTween.rotateX(gameObject, 0, 0.5f);
            LeanTween.rotateZ(gameObject, 0, 0.5f);
        }        
    }
}
