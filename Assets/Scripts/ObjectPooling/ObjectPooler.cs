using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
	public GameObject Object;
	public int Amount = 10;
	public bool Grow = true;

	[HideInInspector]
	public ObjectPooler current;

	private List<GameObject> _pool;

	void Awake ()
	{
		current = this;
	}

	void Start ()
	{
		_pool = new List<GameObject> ();

		for (int i = 0; i < Amount; i++)
		{
			GameObject _object = (GameObject)Instantiate (Object);
			_object.SetActive (false);
			_pool.Add (_object);
		}
	}

	public GameObject GetPooledObject ()
	{
		for (int i = 0; i < _pool.Count; i++)
		{
			if (!_pool [i].activeInHierarchy)
				return _pool [i];
		}

		if (Grow)
		{
			GameObject _object = (GameObject)Instantiate (Object);

			_pool.Add (_object);

			return _object;
		}

		return null;
	}
}
