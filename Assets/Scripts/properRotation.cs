using UnityEngine;
using System.Collections;

public class properRotation : MonoBehaviour {

	void compensateRotation (int speed){
		this.transform.Rotate (new Vector3(0, 0, Time.deltaTime * speed));
	}
}
