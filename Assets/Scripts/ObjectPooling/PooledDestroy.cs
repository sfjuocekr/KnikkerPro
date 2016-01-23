using UnityEngine;
using System.Collections;

public class PooledDestroy : MonoBehaviour
{
	public bool Timer = true;
	public float AliveTime = 10f;

	void OnEnable ()
	{
		Invoke ("Destroy", AliveTime);
	}

	void Destroy ()
	{
		gameObject.SetActive(false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}
