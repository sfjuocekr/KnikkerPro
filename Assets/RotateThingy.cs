using UnityEngine;
using System.Collections;

public class RotateThingy : MonoBehaviour
{
	public float Speed = 90f;

	public bool X = false;
	public bool Y = false;
	public bool Z = false;

	void FixedUpdate ()
	{
		Vector3 _direction = new Vector3 (X ? 1f : 0f, Y ? 1f : 0f, Z ? 1f : 0f);

		transform.RotateAround (transform.position, _direction, Speed * Time.fixedDeltaTime);
	}
}
