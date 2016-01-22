using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
	void LateUpdate () {
		transform.LookAt (GameObject.FindGameObjectWithTag ("Player").transform);
	}
}
