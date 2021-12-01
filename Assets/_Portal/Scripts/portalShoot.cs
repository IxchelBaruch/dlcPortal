using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalShoot : MonoBehaviour
{
    public GameObject bluePortal;
    public GameObject orangePortal;
    public GameObject playerObject;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//blue portal
        {
            SoundManager.instance.Play("ShootBlue");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Portable"))
                {
                    bluePortal.SetActive(true);
                    bluePortal.transform.position = hit.point;                    
                    bluePortal.transform.LookAt(new Vector3(playerObject.transform.position.x, bluePortal.transform.position.y, playerObject.transform.position.z));
                    bluePortal.transform.rotation = Quaternion.FromToRotation(bluePortal.transform.forward, hit.normal) * bluePortal.transform.rotation;
                }
            }
        }

        if (Input.GetButtonDown("Fire2"))//orange portal
        {
            SoundManager.instance.Play("ShootRed");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Portable"))
                {
                    orangePortal.SetActive(true);
                    orangePortal.transform.position = hit.point;
                    orangePortal.transform.LookAt(new Vector3(playerObject.transform.position.x, orangePortal.transform.position.y, playerObject.transform.position.z));
                    orangePortal.transform.rotation = Quaternion.FromToRotation(orangePortal.transform.forward, hit.normal) * orangePortal.transform.rotation;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cubeDestroy"))
        {
            bluePortal.SetActive(false);
            orangePortal.SetActive(false);
        }
    }
}
