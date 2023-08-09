using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle the touch input across device to activate methods on raycasted colliders.
/// </summary>
public class TouchInputHandler : MonoBehaviour
{
    [Tooltip("Factor at which force will act on spheres")]
    public float hitForce;

    void Update()
    {
        /// Handle input across Android & ios platforms
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        /// Handle input in editor
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }
    }

    /// method to cast a ray across 3D particles and add a force variable to them
    private void checkTouch(Vector3 pos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.yellow);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                Debug.Log(hit.rigidbody.gameObject);
                hit.collider.gameObject.GetComponent<ResetPosition>().waitonActivation();
                hit.rigidbody.AddForce(-ray.direction * hitForce);               
            }
        }
    }
}
