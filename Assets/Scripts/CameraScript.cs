using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject ball;
    private Vector3 offset;
    private Vector3 mAngles;
    private Vector3 scroll;
    private float sensitivityH = 2.0f;
    private float sensitivityV = 1.0f;
    void Start()
    {
        ball = GameObject.Find("Ball");
        offset = this.transform.position - ball.transform.position;
        mAngles = this.transform.eulerAngles;
    }

    private void Update()
    {
       mAngles.y += Input.GetAxis("Mouse X") * sensitivityH;
       mAngles.x -= Input.GetAxis("Mouse Y") * sensitivityV;
       
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if ((offset.y < ball.transform.position.y + 1) && zoom > 0) {
            zoom = 0;
        }
        offset.y -= zoom;
        offset.z += zoom * 0.5f;

        if (mAngles.x > 75f) mAngles.x = 75f;
        if (mAngles.x < 35f) mAngles.x = 35f;

        if (mAngles.y > 360) mAngles.y -= 360;
        if (mAngles.y < 0) mAngles.y += 360;

    }

    void LateUpdate()
    {
        this.transform.position = ball.transform.position + 
            Quaternion.Euler(0, mAngles.y, 0) * offset;
        this.transform.eulerAngles = mAngles;
    }
}
    