using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointageCamera : MonoBehaviour {

	// Use this for initialization
	public Camera cam2;

	private bool modePointage;
	private Vector3 lastMouse = Vector3.one;
	private Vector3 hitPoint;
	void Start () {
		modePointage = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		RaycastHit hit;

		if (!cam2.enabled) {return;}

		if (Input.GetButtonDown("Fire1")) {
			modePointage = !modePointage;
			if (Cursor.lockState == CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.None;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		if (modePointage) {
			Ray ray = cam2.ScreenPointToRay(Input.mousePosition);
			if (Input.GetButtonDown("Fire2")) {
				if (Physics.Raycast(ray, out hit)) {
					 // Debug.DrawLine(ray.origin, hit.point);

					 lastMouse = Input.mousePosition;
					 hitPoint = hit.point;

					 Vector3 axe = -Vector3.Cross(ray.direction, transform.TransformDirection(Vector3.forward)).normalized;
					 transform.RotateAround(transform.position, axe, Vector3.Angle(ray.direction, transform.TransformDirection(Vector3.forward)));
					 // Debug.Log(Vector3.Dot(ray.direction, transform.TransformDirection(Vector3.forward))+" "+Vector3.Cross(ray.direction, transform.TransformDirection(Vector3.forward)));
				}
			}

			if (lastMouse !=  Vector3.one) {
				Vector3 diffM = lastMouse - (Vector3) Input.mousePosition;

				lastMouse = Input.mousePosition;

				transform.Translate(Vector3.forward * diffM.y * Time.deltaTime);
				transform.RotateAround(hitPoint, Vector3.up, diffM.x * 3 *  Time.deltaTime);

				//Debug.Log("Not infinte "+diffM);
			}

			if (Input.GetButtonUp("Fire2")) {
				lastMouse = Vector3.one;
				Debug.Log("One "+lastMouse);
			}
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 40 * Time.deltaTime);
			transform.RotateAround(transform.position, transform.TransformDirection(Vector3.left), Input.GetAxis("Mouse Y") * 40 * Time.deltaTime);
		}		
	}
}
