using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickyJoint : MonoBehaviour
{
	private List<string> _colliderNames;

	void Start ()
	{
		_colliderNames = GameObject.FindGameObjectWithTag ("Player").GetComponent<MarbleController> ().ColliderNames;
	}

	void OnCollisionEnter (Collision _collision)
	{
		foreach (string _tableName in _colliderNames)
			if (_collision.gameObject.name == _tableName)
			{
				FixedJoint _joint = gameObject.GetComponent<FixedJoint> ();

				if (_joint == null) 
					_joint = gameObject.AddComponent<FixedJoint> ();
				
				_joint.connectedBody = _collision.rigidbody;
			}
	}

	void OnCollisionExit (Collision _collision)
	{
		foreach (string _tableName in _colliderNames)
			if (_collision.gameObject.name == _tableName)
			{
				Destroy (gameObject.GetComponent<FixedJoint> ());
			}
	}
}
