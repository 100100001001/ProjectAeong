using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ��� ȸ������ ��, ����Ƽ ī�޶� ȸ���ϴ� ���
public class GyroCamera : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotfix; // ������ ȸ����

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
        // ȸ�� ��ȯ
        transform.rotation = gyro.attitude;
    }
}
