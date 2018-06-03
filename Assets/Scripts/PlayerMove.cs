using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	CharacterController personControll;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Awake(){
		personControll = GetComponent<CharacterController> ();
	}

	void Move(){
		float horiz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		Vector3 moveDirSide = transform.right * horiz * moveSpeed;
		Vector3 moveDirForward = transform.forward * vert * moveSpeed;

		personControll.SimpleMove (moveDirSide);
		personControll.SimpleMove (moveDirForward);
	}
}
