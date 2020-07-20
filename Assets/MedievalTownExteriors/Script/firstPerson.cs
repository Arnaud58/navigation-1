using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPerson : MonoBehaviour {

	

	public Camera cam1;
	public float speedJump = 2f;

	private Vector3 oldLean;
	private bool freeLook;
	private bool isJumpping;
	private int uppingMax = 20, upping = 0;
	private int downingMax = 20, downing = 0;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		freeLook = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!cam1.enabled) {return;}

		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		RaycastHit hit;
		Vector3 directionRegard, directionTorse;

		if (Input.GetKey("q") && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1, layerMask)) {
			transform.Translate(20 * Vector3.left * Time.deltaTime);
		} else if (Input.GetKey("d")  && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1, layerMask)) {
			transform.Translate(20 * Vector3.right * Time.deltaTime);
		}

		if (Input.GetKeyDown("a")) {
			oldLean = transform.position;
			transform.RotateAround(new Vector3(transform.position.x,0,transform.position.z),  transform.TransformDirection(Vector3.forward), 20);
		}
		if (Input.GetKeyDown("e")) {
			oldLean = transform.position;
			transform.RotateAround(new Vector3(transform.position.x,0,transform.position.z),  transform.TransformDirection(Vector3.forward), -20);
		}

		if (Input.GetKeyUp("e")) {
			transform.RotateAround(new Vector3(transform.position.x,0,transform.position.z),  transform.TransformDirection(Vector3.forward), 20);
			transform.position = oldLean;
		}

		if (Input.GetKeyUp("a")) {
			transform.RotateAround(new Vector3(transform.position.x,0,transform.position.z),  transform.TransformDirection(Vector3.forward), -20);
			transform.position = oldLean;
		}

		if (Input.GetKeyDown("i")) {
			if (Cursor.lockState == CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.None;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
		if (Input.GetKeyDown("f")) {
			freeLook = !freeLook;
		}

		if (isJumpping) {
			if (upping < uppingMax) {
				upping++;
				transform.Translate(speedJump*Vector3.up*Time.deltaTime);
			}

			if (upping == uppingMax) {
				downing++;
				transform.Translate(-speedJump*Vector3.up*Time.deltaTime);
			}

			if (downing==downingMax) {
				isJumpping=false;
				downing=0;
				upping=0;
			}
		}

		if (Input.GetKeyDown("space") && !isJumpping) {
			downing=0;
			upping=0;
			isJumpping = true;
		} 

		if (Input.GetKey("z")) {
			if (freeLook && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1, layerMask)) {
				transform.Translate(20 * Vector3.forward * Time.deltaTime);
			} else {
				directionRegard = transform.TransformDirection(Vector3.forward);
				directionTorse = new Vector3(directionRegard.x,0,directionRegard.z);

				if (!Physics.Raycast (transform.position, directionTorse, out hit, 1, layerMask)) {
					transform.position += 20 * (directionTorse) * Time.deltaTime;
				}
			}
		} else if (Input.GetKey("s")) {
			if (freeLook && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1, layerMask)) {
				transform.Translate(20 * Vector3.back * Time.deltaTime);
			} else {
				directionRegard = transform.TransformDirection(Vector3.back);
				directionTorse = new Vector3(directionRegard.x,0,directionRegard.z);

				if (!Physics.Raycast (transform.position, directionTorse, out hit, 1, layerMask)) {
					transform.position += 20 * (directionTorse) * Time.deltaTime;
				}
			}
		}

		directionRegard = transform.TransformDirection(Vector3.forward);
		directionTorse = new Vector3(directionRegard.x,0,directionRegard.z);

		transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 40 * Time.deltaTime);Quaternion oldRotate = transform.rotation;
		transform.RotateAround (transform.position, transform.TransformDirection (Vector3.left), Input.GetAxis ("Mouse Y") * 40 * Time.deltaTime);

		if (transform.eulerAngles.x>88 && transform.eulerAngles.x<272) {
			transform.rotation = oldRotate;
			//transform.RotateAround (transform.position, transform.TransformDirection (Vector3.left), Input.GetAxis ("Mouse Y") * -40 * Time.deltaTime);
		}
		// Debug.Log(transform.eulerAngles);
	}
}
