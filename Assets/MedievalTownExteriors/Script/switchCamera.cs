using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class switchCamera : MonoBehaviour {

	private bool cam1Act;
	public Camera cam1;
    public Camera cam2;

	void Start () {
		cam1Act = true;
		cam1.enabled = cam1Act;
		cam2.enabled = !cam1Act;
	}
	public void switchToCamera() {
        cam1Act = !cam1Act;
		cam1.enabled = cam1Act;
		cam2.enabled = !cam1Act;
	}
}
