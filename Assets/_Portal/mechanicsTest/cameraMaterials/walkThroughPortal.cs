using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkThroughPortal : MonoBehaviour
{
    GameObject playerObject;
    Rigidbody playerRBody;

    public Transform otherPortal;

    bool overlaping = false;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerRBody = playerObject.GetComponent<Rigidbody>();
    }

    /*
           float rotationDiff = -Quaternion.Angle(transform.rotation, otherPortal.rotation);
           rotationDiff += 180; //cambiar esto luego
           playerObject.transform.Rotate(Vector3.up, rotationDiff);

           Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) //esto rota al jugador
               * playerObject.transform.position - transform.position;

           playerObject.transform.position = otherPortal.position; // esto mueve al jugador

           overlapingPortal = false;
    */


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("portalTrigger"))
        {

            Vector3 playerFromPortal = transform.InverseTransformPoint(playerObject.transform.position);

            //if(playerFromPortal.z <= 0.02)
            //{
                playerObject.transform.position = otherPortal.position + (otherPortal.forward * 0.2f) - new Vector3(0,1,0);//tp player

                Quaternion cosaMisteriosa = Quaternion.Inverse(transform.rotation) * playerObject.transform.rotation;
                playerObject.transform.eulerAngles = Vector3.up * (otherPortal.eulerAngles.y - (transform.eulerAngles.y - playerObject.transform.eulerAngles.y) + 180);
                Vector3 playerCamAngles = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (otherPortal.eulerAngles.x + Camera.main.transform.localEulerAngles.x);

                playerRBody.velocity = playerRBody.velocity.magnitude * otherPortal.forward;

            //}


            
            
            

        }
    }
}
