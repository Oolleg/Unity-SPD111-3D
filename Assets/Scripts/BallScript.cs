using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;
    [SerializeField]
    private Light mainLight;


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

        if(Input.GetKeyDown(KeyCode.N))
        {
            if(RenderSettings.skybox == daySkybox)
            {
                RenderSettings.skybox = nightSkybox;
                RenderSettings.skybox.SetFloat("_Exposure", 0f);
                RenderSettings.ambientIntensity = 0f;
                mainLight.intensity = 0f;
            }
            else
            {
                RenderSettings.skybox = daySkybox;
                RenderSettings.skybox.SetFloat("_Exposure", 1f);
                RenderSettings.ambientIntensity = 1f;
                mainLight.intensity = 1f;
            }
        }
    }
}
