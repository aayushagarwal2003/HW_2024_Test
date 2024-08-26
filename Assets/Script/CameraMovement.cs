using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform doofus;    
    public Vector3 offset;      
    public float smoothSpeed = 0.125f;  

    void LateUpdate()
    {
        
        Vector3 desiredPosition = doofus.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        
        transform.position = smoothedPosition;

        
        transform.LookAt(doofus);
    }
}
