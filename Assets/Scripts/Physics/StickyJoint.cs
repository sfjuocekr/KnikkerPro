using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickyJoint : MonoBehaviour
{
	private List<string> _tableNames;

	void Start ()
	{
		_tableNames = GameObject.FindGameObjectWithTag ("Player").GetComponent<MarbleController> ().TableNames;
	}

	void OnCollisionEnter (Collision _collision)
	{
		foreach (string _tableName in _tableNames)
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
		foreach (string _tableName in _tableNames)
			if (_collision.gameObject.name == _tableName)
			{
				Destroy (gameObject.GetComponent<FixedJoint> ());
			}
	}
}
