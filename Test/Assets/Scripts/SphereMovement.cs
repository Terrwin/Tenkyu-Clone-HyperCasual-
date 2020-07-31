using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereMovement : MonoBehaviour
{   
    private Rigidbody platform = null;
    private float xAngle, yAngle; 

    void FixedUpdate()
    {
        Rotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (platform != other.gameObject.GetComponent<Rigidbody>())
        {
            platform = other.gameObject.GetComponent<Rigidbody>();
            xAngle = 0;
            yAngle = 0;
        }
    }

    private void Rotation()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved && platform != null)
            {
                xAngle -= Input.GetAxis("Mouse X") / 40;
                yAngle -= Input.GetAxis("Mouse Y") / 40;
                xAngle = Mathf.Clamp(xAngle, -30, 30);
                yAngle = Mathf.Clamp(yAngle, -30, 30);
                platform.rotation = Quaternion.Euler(xAngle, 0f, yAngle);
            }
        }
    }
}
