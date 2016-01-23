using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

#if UNITY_PLAYER
using UnityEngine.SceneManagement;
#endif

public class EndGame : MonoBehaviour
{
	void OnCollisionEnter (Collision _collision)
	{
		if (_collision.gameObject.tag == "Player")
		{
			Debug.Log ("Player Wins!");

			#if UNITY_EDITOR
			EditorSceneManager.LoadScene (0);
			#endif

			#if UNITY_PLAYER
			SceneManager.LoadScene (0);
			#endif
		}
	}
}
