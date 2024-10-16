using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It's rotating time, aw yeah (please end me)
/// </summary>
public class Rotater : MonoBehaviour
{
    [SerializeField, Tooltip("The rotation speed in degrees per second.")]
    private Vector3 rotation;
    
    private void FixedUpdate()
    {
        transform.Rotate(rotation * Time.fixedDeltaTime);
    }
}
