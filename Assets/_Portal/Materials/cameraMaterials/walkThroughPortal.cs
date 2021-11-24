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

    private void Update()
    {
        //print("velocidad: " + playerRBody.velocity);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("portalTrigger") && !overlaping)
        {
            /*overlaping = true;
            Vector3 playerFromPortal = transform.InverseTransformPoint(playerObject.transform.position);

            if(playerFromPortal.z <= 0.02)
            {
                playerObject.transform.position = otherPortal.position + new Vector3(-playerFromPortal.x, +playerFromPortal.y, -playerFromPortal.z);

                Quaternion cosaMisteriosa = Quaternion.Inverse(transform.rotation) * playerObject.transform.rotation;
                playerObject.transform.eulerAngles = Vector3.up * (otherPortal.eulerAngles.y - (transform.eulerAngles.y - playerObject.transform.eulerAngles.y) + 180);
                Vector3 playerCamAngles = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (otherPortal.eulerAngles.x + Camera.main.transform.localEulerAngles.x);

                Vector3 localPlayerVelocity = thisPortal.InverseTransformPoint(playerObject.GetComponent<Rigidbody>().velocity);
                playerObject.GetComponent<Rigidbody>().velocity = -otherPortal.transform.forward * playerObject.GetComponent<Rigidbody>().velocity.y * 2;            

            }*/

            /*
            print("velocidad previa: " + playerRBody.velocity);

            

            print("other portal: " + otherPortal.forward);

            float anglex = Vector3.Angle(Vector3.Scale(playerRBody.velocity, new Vector3 (1,0,0)), Vector3.Scale(transform.forward, new Vector3(1, 0, 0)));
            float angley = Vector3.Angle(Vector3.Scale(playerRBody.velocity, new Vector3(0, 1, 0)), Vector3.Scale(transform.forward, new Vector3(0, 1, 0)));
            float anglez = Vector3.Angle(Vector3.Scale(playerRBody.velocity, new Vector3(0, 0, 1)), Vector3.Scale(transform.forward, new Vector3(0, 0, 1)));

            print(anglex + " " + angley + " " + anglez);

            */

            //print("velocidad previa: " + playerRBody.velocity);

            /*Vector3 localPlayerVelocity = transform.InverseTransformPoint(playerRBody.velocity);
            playerRBody.velocity = Vector3.Scale(-otherPortal.transform.forward * 10, localPlayerVelocity);*/

            //print(playerRBody.velocity.magnitude * otherPortal.forward);

            playerRBody.velocity = playerRBody.velocity.magnitude * otherPortal.forward;

            playerObject.transform.position = otherPortal.position + (otherPortal.forward * 0.1f);//tp player
            
            

        }
    }
}
