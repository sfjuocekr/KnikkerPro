using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
	public float _spawnRate;

	private ObjectPooler _objectPooler;

	void Awake ()
	{
		_objectPooler = gameObject.GetComponent<ObjectPooler> ();
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

		Vector3 _scale = _object.transform.localScale;
		_scale.x = _scale.y = _scale.z = Random.Range (0.5f, 0.75f);

		_object.transform.localScale = _scale;
		_object.transform.rotation = Quaternion.identity;
		_object.SetActive (true);
	}
}