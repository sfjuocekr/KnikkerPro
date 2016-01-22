using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	Vector3 offset;

	void Start () {
		offset = transform.position - GameObject.FindGameObjectWithTag ("Player").transform.position;
	}

	void LateUpdate () {
		Vector3 _targetCamPos = GameObject.FindGameObjectWithTag ("Player").transform.position + offset;

		transform.position = Vector3.Lerp (transform.position, _targetCamPos, 10f * Time.deltaTime);
	}
}
