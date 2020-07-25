using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereMovement : MonoBehaviour
{   
    public Transform obj1;
    public Transform obj2;
    public Transform obj3;
    public Transform obj4;
    public Transform cam;
    private Transform transform1;
    public int level = 0;
    private Rigidbody rigidbody;
    public float X, Y; 
    float Xnorm, Ynorm;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
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
        if (other.gameObject.tag == "NextLevel")
        {
            level += 1;
            Xnorm = 0;
            Ynorm = 0;
            X = 0;
            Y = 0;
        }
    }

    private void Rotation()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                X -= Input.GetAxis("Mouse X") / 12;
                Y -= Input.GetAxis("Mouse Y") / 12;
                if (X > 30)
                {
                    X = 30;
                }
                else if (X < -30)
                {
                    X = -30;
                }
                if (Y > 30)
                {
                    Y = 30;
                }
                else if (Y < -30)
                {
                    Y = -30;
                }
                Xnorm = Mathf.Clamp(X, -30, 30);
                Ynorm = Mathf.Clamp(Y, -30, 30);
            }
        }
        if (level == 0)
        {
            obj1.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Xnorm, 0f, Ynorm);
        }
        else if (level == 1)
        {
            obj2.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Xnorm, 0f, Ynorm);
        }
        else if (level == 2)
        {
            obj3.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Xnorm, 0f, Ynorm);
        }
        else if (level == 3)
        {
            obj4.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Xnorm, 0f, Ynorm);
        }
    }
}
