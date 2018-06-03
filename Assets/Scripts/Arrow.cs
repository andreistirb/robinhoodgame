using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	private bool attached = false;

	private bool isFired = false;

	void OnTriggerStay() {
		AttachArrow ();
	}

	void OnTriggerEnter() {
		AttachArrow ();
	}

	void Update() {
		if (isFired && transform.GetComponent<Rigidbody> ().velocity.magnitude > 5f) {
			transform.LookAt (transform.position + transform.GetComponent<Rigidbody> ().velocity);
		}
	}

	public void Fired() {
		isFired =  true; 
	}

	private void AttachArrow() {
		//var mDevice = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
		if (!attached ){ //&& mDevice.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//ArrowShoot.Instance.AttachBowToArrow ();
			attached = true;
		}
	}


}
