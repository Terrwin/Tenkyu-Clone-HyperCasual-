using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject target;
    void FixedUpdate()
    {
        Vector3 offset = new Vector3(-20, 10, 0);
        transform.position = target.transform.position + offset;
    }
}
