using UnityEngine;
using System.Collections;

public class waterBehaviour : MonoBehaviour {

	private float dead = 5f;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Peeps") {
			Debug.Log ("TRIGGERED");
			col.SendMessage("reduceSpeed");
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Peeps") {
			col.SendMessage("increaseSpeed");
		}
	}

	void Update () {
		dead -= Time.deltaTime;
		if (dead <= 0) {Destroy (this.gameObject);}
	}
}
