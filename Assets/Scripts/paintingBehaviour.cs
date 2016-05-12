using UnityEngine;
using System.Collections;

public class paintingBehaviour : MonoBehaviour {

	private float health = 500f;
	private UnityEngine.UI.Text text;

	public GameObject loseCanvas;

	public GameObject Text;

	// Use this for initialization
	void Start () {
		text = Text.GetComponent<UnityEngine.UI.Text>();
		text.text = health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Time.timeScale = 0.0f;
			loseCanvas.SetActive (true);
		}
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Peeps") {
			col.SendMessage ("yell");
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Peeps") {
			col.SendMessage ("dontYell");
		}
	}

	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Peeps") {
			health -= Time.deltaTime;
			text.text = Mathf.Ceil(health).ToString();
		}
	}
}
