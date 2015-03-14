using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public Camera followCam;
	public Camera topDownCam;
	public Camera closeUpCam;

	private Camera[] cameras;

	// Use this for initialization
	void Start () {
		followCam.enabled = true;
		topDownCam.enabled = false;
		closeUpCam.enabled = false;

		cameras = new Camera[]{followCam, topDownCam, closeUpCam};
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			for(int i = 0; i < cameras.Length; i++){
				Camera camera = cameras[i];
				if(camera.enabled){
					camera.enabled = false;
					cameras[(i+1) % cameras.Length].enabled = true;
					break;
				}
			}
		}
	}
}
