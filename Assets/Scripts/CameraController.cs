using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("player")]
    public GameObject targetObj;

    private Vector3 targetPos;

    [SerializeField]
    private float cameraRotateSpeed = 200f;

    [SerializeField]
    private float maxLimit = 30.0f;

    private float miniLimit;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;
        miniLimit = 360 - maxLimit;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObj != null)
        {
            transform.position += targetObj.transform.position - targetPos;

            targetPos = targetObj.transform.position;
        }
        //if (Input.GetMouseButton(0))
        //{
            RotateCamera();
        //}
    }
    private void RotateCamera()
    {
        float x = Input.GetAxis("Axis 7");
        float z = Input.GetAxis("Axis 8");

        transform.RotateAround(targetObj.transform.position, Vector3.up, x * Time.deltaTime * cameraRotateSpeed);

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

