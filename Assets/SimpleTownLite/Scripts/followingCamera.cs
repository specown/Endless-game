using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingCamera : MonoBehaviour {

    private Transform lookAt;
    private float smoothSpeed = 0.125f;
    private Vector3 offset;

    //LateUpdate due to Object is updated in 'Update'
    void LateUpdate()
    {
        //Lock camera position
        offset = new Vector3(0, 10, -6);

        //Find Player
        lookAt = GameObject.Find("Player").GetComponent<Transform>();

        Vector3 desiredPosition = lookAt.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(lookAt);
    }
}
