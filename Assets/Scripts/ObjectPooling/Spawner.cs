using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
	public float _spawnRate;

	private ObjectPooler _objectPooler;

	void Awake ()
	{
		_objectPooler = GetComponent<ObjectPooler> ();
	}

	void Start ()
	{
		InvokeRepeating ("Spawn", _spawnRate, _spawnRate);
	}

	void Spawn()
	{
		GameObject _object = _objectPooler.current.GetPooledObject ();

		if (_object == null)
			return;

		_object.transform.position = transform.position;
		_object.SetActive (true);
	}
}