using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeUpright : MonoBehaviour
{
    public bool moveUpright = false;

    Quaternion myQuat;
    Quaternion targetQuat;

    void Start()
    {
        myQuat = Quaternion.Euler(transform.localEulerAngles);        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetQuat = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0));

        if(moveUpright)
        {            
            transform.localRotation = Quaternion.RotateTowards(myQuat, targetQuat, 2);            
        }
        if (transform.localEulerAngles.x == 0 || transform.localEulerAngles.z == 0)
            moveUpright = false;

        myQuat = Quaternion.Euler(transform.localEulerAngles);
    }
}
