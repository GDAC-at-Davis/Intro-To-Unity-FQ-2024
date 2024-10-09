using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private bool shouldFollow;
    
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }
    
    private void LateUpdate()
    {
        if (shouldFollow)
        {
            float t = 1 - Mathf.Pow(0.01f, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target.position + offset, t);
        }
    }
}
