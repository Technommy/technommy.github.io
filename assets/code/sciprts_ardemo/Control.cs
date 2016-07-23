using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		moveSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		print (Input.GetAxis ("Horizontal"));
		transform.Translate (moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, 0f);
	}
}
