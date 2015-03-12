using UnityEngine;
using System.Collections;

public class LevitationController : MonoBehaviour {

	public float hoverForce = 12f;
	public int delay;

	private bool isActive;
	private Light light;

	// Use this for initialization
	void Start () {
		isActive = false;
		light = (Light)transform.FindChild("SpotLight").GetComponent(typeof(Light));
		light.enabled = false;

		InvokeRepeating ("switchLevitation", delay, delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void switchLevitation(){
		if (isActive) {
			//Turn it off
			isActive = false;
			light.enabled = false;
		} else {
			//Turn it on
			isActive = true;
			light.enabled = true;
		}
	}

	void OnTriggerStay(Collider other){

		if (!isActive) {
			other.attachedRigidbody.AddForce(Vector3.down * hoverForce, ForceMode.Acceleration);
			other.attachedRigidbody.constraints = RigidbodyConstraints.None;
			return;
		}

		other.attachedRigidbody.AddForce (Vector3.up * hoverForce);
		other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		Debug.Log ("Inside ");
	}
}
