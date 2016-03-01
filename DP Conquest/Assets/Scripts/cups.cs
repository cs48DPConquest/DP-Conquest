using UnityEngine;
using System.Collections;

public class cups : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
			Goals.g += 1;
			Destroy (gameObject);
		}
	}
}
