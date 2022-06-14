using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모바일 기기 회전했을 때, 유니티 카메라도 회전하는 기능
public class GyroCamera : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotfix; // 수정된 회전값

    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        GameObject camParent = new GameObject("camParent");
        
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        // 회전 변환
        transform.rotation = gyro.attitude;
    }
}
