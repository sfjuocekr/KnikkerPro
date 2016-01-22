using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
	public ObjectPooler current;
	public GameObject pooledObject;
	public int m_PooledAmount = 10;
	public bool m_WillGrow = true;
	public List<GameObject> m_PooledObjects;

	void Awake ()
	{
		current = this;
	}

	void Start ()
	{
		m_PooledObjects = new List<GameObject> ();

		for (int i = 0; i < m_PooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			m_PooledObjects.Add (obj);
		}
	}

	public GameObject GetPooledObject ()
	{
		for (int i = 0; i < m_PooledObjects.Count; i++) {
			if (!m_PooledObjects [i].activeInHierarchy) {
				return m_PooledObjects [i];
			}
		}
		if (m_WillGrow) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			m_PooledObjects.Add (obj);

			return obj;
		}

		return null;
	}
}
