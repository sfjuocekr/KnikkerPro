using UnityEngine;
using System.Collections;

public class RotateThingy : MonoBehaviour
{
	public float Speed = 90f;

	void FixedUpdate ()
	{
		transform.RotateAround (transform.position, transform.forward, Speed * Time.fixedDeltaTime);
	}
}
