using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour
{
    public Transform ownPortal;
    public Transform otherCamera;

    private void Update()
    {
        Vector3 playerDistance = ownPortal.InverseTransformPoint(Camera.main.transform.position); //calcula el ofset del jugador a propio portal
        otherCamera.localPosition = -new Vector3(playerDistance.x, -playerDistance.y, playerDistance.z); //mueve la otra camara proporcionalmente con el ofset

        Quaternion playerCameraDirection = Quaternion.Inverse(ownPortal.rotation) * Camera.main.transform.rotation;
        otherCamera.localEulerAngles = new Vector3(playerCameraDirection.eulerAngles.x, playerCameraDirection.eulerAngles.y + 180, playerCameraDirection.eulerAngles.z);
    }
}
