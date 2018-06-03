using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour {

	public GameObject arrowPrefab;
	private GameObject currentArrow;
	public GameObject stringAttachPoint;
	public GameObject stringStartPoint;
	public GameObject arrowStartPoint;
	public GameObject mBow;
	public GameObject player;
	public static ArrowShoot Instance;

	public bool isAttached = false;

	void Awake() {
		if (Instance == null)
			Instance = this;
	}

	void OnDestroy() {
		if (Instance == this)
			Instance = null;
	}

	// Use this for initialization
	void Start () {
		//arrowPrefab = Resources.Load ("Arrow") as GameObject;
	}

	private void AttachArrow() {
		if (currentArrow == null) {
			Debug.Log ("e nul obiectul....");
			currentArrow = Instantiate (arrowPrefab) as GameObject;
			currentArrow.transform.parent = mBow.transform;
			currentArrow.transform.localPosition = mBow.transform.localPosition + new Vector3 (0f, 0f, 2.5f);//.11f, 1.76f); 
			currentArrow.transform.localRotation = Quaternion.identity;
			currentArrow.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
			isAttached = true;
		} else {
			if (isAttached) {
				currentArrow.transform.localPosition = mBow.transform.localPosition + new Vector3 (0f, 0f, 15f);
				currentArrow.transform.localRotation = Quaternion.identity;
				currentArrow.transform.localScale = new Vector3 (5f, 5f, 5f);//(1.5f, 1.5f, 1.5f);
			}
			//Debug.Log ("muta sageaaata");

		}
	}

	private void PullString() {
		if (isAttached) {
			
			float dist = stringStartPoint.transform.position.magnitude / 15f; //- trackedObj.transform.position).magnitude;
			stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition  + new Vector3 (dist, 0f, 0f);
			currentArrow.transform.localPosition = currentArrow.transform.localPosition - new Vector3 (dist, 0f, 0f);
		}
	}

	private void Fire() {
		float dist = 1;//(stringStartPoint.transform.position - trackedObj.transform.position).magnitude;

		currentArrow.transform.parent = null;
		//currentArrow.GetComponent<Arrow> ().Fired ();

		Rigidbody r = currentArrow.GetComponent<Rigidbody> ();
		r.velocity = currentArrow.transform.forward * 25f * dist;
		r.useGravity = true;

		currentArrow.GetComponent<Collider> ().isTrigger = false;

		stringAttachPoint.transform.position = stringStartPoint.transform.position;

		currentArrow = null;
		isAttached = false;
	}

	// Update is called once per frame
	void Update () {
		AttachArrow ();
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Am apasat mouseul");
			PullString ();
		}
		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("Am lasat mouseul in pace");
			Fire ();
		}
			
	}

	/*public void AttachBowToArrow() {
		currentArrow.transform.parent = stringAttachPoint.transform;
		currentArrow.transform.position = arrowStartPoint.transform.position;
		currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

		isAttached = true;
	}*/
}
