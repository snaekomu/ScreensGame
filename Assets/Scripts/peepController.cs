using UnityEngine;
using System.Collections;
using System;

public class peepController : MonoBehaviour {

	public GameObject[] artsy;
	private Vector3 destination;
	private Rigidbody rb;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> ();
		artsy = GameObject.FindGameObjectsWithTag ("Art");
		int n = UnityEngine.Random.Range (0, artsy.Length);
		destination = artsy [n].GetComponent<Transform> ().position;

	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (destination);
	}
}
