using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float moveSpeed = 10f;
    private float dt;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		agent.Move(Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis ("Horizontal") + Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis ("Vertical"));

    }
}
