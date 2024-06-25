using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    private float forceFactor = 2f;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        float fx = Input.GetAxis("Horizontal") * Time.timeScale * forceFactor;
        float fz = Input.GetAxis("Vertical") * Time.timeScale * forceFactor;
        //rb.AddForce(fx, 0, fz);
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        camForward = camForward.normalized;

        Vector3 moveDirecton = 
            fz * camForward +
            fx * Camera.main.transform.right;
        rb.AddForce(moveDirecton);
    }
}
