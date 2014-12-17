using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D fortress) {
		if(fortress.gameObject.tag == "Enemys")
			Debug.Log("Damage");
	}
}
