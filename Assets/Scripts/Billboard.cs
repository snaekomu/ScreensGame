using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("Perspective");
	}
	
	// Update is called once per frame
	void Update() 
	{
		transform.LookAt(cam.transform.position, -Vector3.forward);
	}
}
