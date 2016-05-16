using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
    private Vector3 prevMousePos;
    private Vector3 movingForce;
    
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0)) { prevMousePos = Input.mousePosition; }
        if (Input.GetMouseButton(0))
        {
            movingForce = prevMousePos - Input.mousePosition;
            prevMousePos = Input.mousePosition;
        }

        transform.Translate(movingForce /10f);
        movingForce /= 1.3f;
	}
}
