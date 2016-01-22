using UnityEngine;
using System.Collections;

public class StickyJoint : MonoBehaviour
{
	void OnCollisionEnter (Collision c)
	{
		if (c.gameObject.tag == "Sticky") {
			SpringJoint _joint = gameObject.AddComponent<SpringJoint> ();
			/*_joint.connectedBody = c.rigidbody;
			_joint.breakForce = 0.1f;
			_joint.minDistance = 0f;
			_joint.maxDistance = 1f;
			_joint.tolerance = 1f;*/
		}
	}

	/*void OnCollisionExit (Collision c)
	{
		if (c.gameObject.tag == "Sticky")
			Destroy (gameObject.GetComponent<SpringJoint> ());
	}*/
}
