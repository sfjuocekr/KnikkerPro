using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
	public float Min = 0f;
	public float Max = 5f;
	public float Speed = 1f;

	public bool X = false;
	public bool Y = false;
	public bool Z = false;

	private float _mid;

	void Awake ()
	{
		_mid = (Min + Max) * 0.5f;
	}

	void Update ()
	{
		Vector3 _position = transform.position;

		if (X)
			_position.x = _mid + Mathf.Sin (Time.time * Speed);

		if (Y)
			_position.y = _mid + Mathf.Sin (Time.time * Speed);

		if (Z)
			_position.z = _mid + Mathf.Sin (Time.time * Speed);

		transform.position = _position;
	}
}
