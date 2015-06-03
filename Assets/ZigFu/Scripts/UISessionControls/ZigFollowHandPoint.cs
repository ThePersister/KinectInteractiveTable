using UnityEngine;
using System;

public class ZigFollowHandPoint : MonoBehaviour
{
    public bool isTopDown = false; // Kinect views from above, so does the camera.
	public Vector3 Scale = new Vector3(0.02f, 0.02f, -0.02f);
	public Vector3 bias;
	public float damping = 5;
    public Vector3 bounds = new Vector3(10, 10, 10);

    Vector3 focusPoint;
	Vector3 desiredPos;
	
	void Start() {
		desiredPos = transform.localPosition;
	}
	
	void Update() {
		transform.position = Vector3.Lerp(transform.position,  desiredPos, damping * Time.deltaTime);
	}

	void Session_Start(Vector3 focusPoint) {
        this.focusPoint = focusPoint;
	}
	
	void Session_Update(Vector3 handPoint) {
        Vector3 pos = handPoint - focusPoint;
        
        if (isTopDown)
            desiredPos = ConvertToTopdown(ClampVector(Vector3.Scale(pos, Scale) + bias, -0.5f * bounds, 0.5f * bounds));
        else
            desiredPos = ClampVector(Vector3.Scale(pos, Scale) + bias, -0.5f * bounds, 0.5f * bounds);

        Debug.Log("Session Updated: Current Pos: " + transform.position + " Desired Pos: " + desiredPos);
	}
	
	void Session_End() {
        desiredPos = Vector3.zero;
	}

    Vector3 ClampVector(Vector3 vec, Vector3 min, Vector3 max) {
        return new Vector3(Mathf.Clamp(vec.x, min.x, max.x),
                           Mathf.Clamp(vec.y, min.y, max.y),
                           Mathf.Clamp(vec.z, min.z, max.z));
    }

    Vector3 ConvertToTopdown(Vector3 vec)
    {
        return new Vector3(vec.x, vec.z, -vec.y);
    }
}