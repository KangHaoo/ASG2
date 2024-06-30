/// <author>Kang Hao</author>
/// <date>2024-06-27</date>
/// /// <summary>
/// Billboard class that makes the object always face the camera.
/// </summary>



/// <remarks>
/// This script should be attached to a GameObject that needs to face the camera at all times.
/// </remarks>
/// <example>
/// Attach this script to a GameObject and assign the camera Transform to the cam field.
/// </example>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Billboard : MonoBehaviour
{
    /// <summary>
    /// The camera Transform that the object will face.
    /// </summary>
    public Transform cam;

    /// <summary>
    /// Called every frame after all Update functions have been called. 
    /// Rotates the object to face the camera.
    /// </summary>
    void LateUpdate()
    {
        // Rotate the object to face the camera
        transform.LookAt(transform.position + cam.forward);
    }
}
