using UnityEngine;
using System.Collections;

public class TableController : MonoBehaviour
{
	private Quaternion _rotation;

	private float _deltaTime;
	private float _horizontal;
	private float _vertical;
	private float _speed;

	private bool _boost;

	private GameObject BallStand;

	private GameObject HorizontalGuide;
	private GameObject VerticalGuide;

	void Start ()
	{
		// I know this is not that nice, but if I wanted to move the controls into Update() it would change all _deltaTimes variables at once ;)
		_deltaTime = Time.fixedDeltaTime;
	}

	void Update ()
	{
		// Controls are updated per frame.
		_horizontal = Input.GetAxisRaw ("Horizontal");
		_vertical = Input.GetAxisRaw ("Vertical");

		// Check if shift is pressed.
		_speed = Input.GetButton ("Fire3") ? 0.4f : 0.2f;
	}

	void FixedUpdate ()
	{
		// Store the current rotation.
		_rotation = transform.rotation;

		// Handle horizontal movement.
		if (_horizontal != 0)
		if (_rotation.x > -0.15 && _rotation.x < 0.15) {
			if (_horizontal > 0)
				_rotation.x += _speed * _deltaTime;
			else if (_horizontal < 0)
				_rotation.x -= _speed * _deltaTime;
		} else if (_rotation.x < -0.15 || _rotation.x > 0.15)
		if (_horizontal > 0 && _rotation.x < -0.15)
			_rotation.x += _speed * _deltaTime;
		else if (_horizontal < 0 && _rotation.x > 0.15)
			_rotation.x -= _speed * _deltaTime;

		// Handle horizontal movement.
		if (_vertical != 0)
		if (_rotation.z > -0.15 && _rotation.z < 0.15) {
			if (_vertical > 0)
				_rotation.z += _speed * _deltaTime;
			else if (_vertical < 0)
				_rotation.z -= _speed * _deltaTime;
		} else if (_rotation.z < -0.15 || _rotation.z > 0.15)
		if (_vertical > 0 && _rotation.z < -0.15)
			_rotation.z += _speed * _deltaTime;
		else if (_vertical < 0 && _rotation.z > 0.15)
			_rotation.z -= _speed * _deltaTime;

		// Update the rotation according to player input.
		transform.rotation = _rotation;
	}
}
