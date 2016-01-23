using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
	public float Speed = 90f;
	public bool X = false;
	public bool Y = false;
	public bool Z = false;
	public bool Physics = false;

	/*private Rigidbody _rigidbody;

	void Awake ()
	{
		_rigidbody = GetComponent<Rigidbody> ();
	}*/

	void Update ()
	{
		if (!Physics)
		{
			Vector3 _direction = new Vector3 (X ? 1f : 0f, Y ? 1f : 0f, Z ? 1f : 0f);
	
			transform.RotateAround (transform.position, _direction, Speed * Time.deltaTime);
		}
	}

	void FixedUpdate ()
	{
		if (Physics)
		{
			//Transform _transform = transform;
			Vector3 _direction = new Vector3 (X ? 1f : 0f, Y ? 1f : 0f, Z ? 1f : 0f);

			transform.RotateAround (transform.position, _direction, Speed * Time.fixedDeltaTime);
			//_transform.RotateAround (transform.position, _direction, Speed * Time.fixedDeltaTime);


			//_rigidbody.MoveRotation (Quaternion.RotateTowards(transform.rotation, _transform.rotation, 90f));
				
			//_rigidbody.AddTorque (_direction * Speed);
		}
	}
}
