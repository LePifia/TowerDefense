using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLooking : MonoBehaviour
{
    
    void Update()
    {
        Vector3 targetVector = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, Camera.main.transform.rotation * Vector3.up);
    }

}
