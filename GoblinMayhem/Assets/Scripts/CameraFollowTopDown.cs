using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowTopDown: MonoBehaviour //Makes the camera follow a target smoothly
{
    [Range(0, 3)] [SerializeField] 
    public float smoothTime = 0.3F; 

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    public Transform target;

    public float camViewX = 3f, camViewY = 0.2f;
    private float camViewZ = -10;

    public void Start()
    {
    }
    void Update()
    {
        CamFollowTopDown();
    }

    public void CamFollowTopDown()
    {
        // Define a target position above and behind the target transform
        targetPosition = target.TransformPoint(new Vector3(camViewX, camViewY, camViewZ));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
