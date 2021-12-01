using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeUpright : MonoBehaviour
{
    void FixedUpdate()
    {
        Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
    }
}
