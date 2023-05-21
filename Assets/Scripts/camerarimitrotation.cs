using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camerarimitrotation : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;
    public float minYAngle = -45f;
    public float maxYAngle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LimitFreeLookYAxis();
    }

    private void LimitFreeLookYAxis()
    {
        float currentYAngle = freeLookCam.m_YAxis.Value * 180f;

        if(currentYAngle < minYAngle)
        {
            freeLookCam.m_YAxis.Value = minYAngle / 180f;
        }
        else if (currentYAngle > maxYAngle)
        {
            freeLookCam.m_YAxis.Value = maxYAngle / 180f;
        }
    }
}
