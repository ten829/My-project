using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("player")]
    public Transform target;

    private Vector3 offset;

    [SerializeField]
    private float cameraRotateSpeed = 200f;

    [SerializeField]
    private float maxLimit = 30.0f;

    private float miniLimit;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        miniLimit = 360 - maxLimit;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        if (Input.GetMouseButton(1))
        {
            RotateCamera();
        }
    }
    private void RotateCamera()
    {
        float x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse Y");
        Vector3 pos = target.position;

        transform.RotateAround(pos, Vector3.up, x * Time.deltaTime * cameraRotateSpeed);

        var localAngle = transform.localEulerAngles;

        localAngle.x += z;

        if (localAngle.x > maxLimit && localAngle.x < 180)
        {
            localAngle.x = maxLimit;
        }

        if (localAngle.x < miniLimit && localAngle.x > 180)
        {
            localAngle.x = miniLimit;
        }
        transform.localEulerAngles = localAngle;
    }
}

