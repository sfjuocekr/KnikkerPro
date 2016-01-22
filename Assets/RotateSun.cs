using UnityEngine;
using System.Collections;

public class RotateSun : MonoBehaviour {
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, 5 * Time.deltaTime);
	}
}
