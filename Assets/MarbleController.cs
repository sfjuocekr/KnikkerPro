using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MarbleController : MonoBehaviour
{
	// A place to save the score of the player, this is hidden from the editor.
	[HideInInspector]
	public static int PlayerScore;

	private Dictionary<string, int> PowerUps;
	private Dictionary<string, Action> Powers;

	private bool _grounded;

	void Start ()
	{
		// Set score to zero when this object is created.
		PlayerScore = 0;

		// We can not jump yet!
		_grounded = false;

		// Initialize the power-up dictionaries.
		Powers = new Dictionary<string, Action> () {
			{ "Jump", () => Jump () }
			//{ "Boost", () => Boost() }
		};

		PowerUps = new Dictionary<string, int> () {
			{ "Jump", 1000 }
			//{ "Boost", 1000 }
		};
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump") && _grounded)
			UsePowerUp ("Jump");

		/*if (Input.GetButtonDown("Fire2") && _grounded)
            UsePowerUp("Boost");*/
	}

	void OnCollisionEnter (Collision _collision)
	{
	}

	void OnCollisionStay (Collision _collision)
	{
		if (_collision.gameObject.name == "TableTop" || _collision.gameObject.name == "Bridge")
			_grounded = true;
	}

	void OnCollisionExit (Collision _collision)
	{
		if (_collision.gameObject.name == "TableTop" || _collision.gameObject.name == "Bridge")
			_grounded = false;
	}

	void AddPowerUp (string _power)
	{
		int _numPower = 1;

		// Try to retrieve the power-up requested and store its value.
		if (PowerUps.TryGetValue (_power, out _numPower)) {
			// Increase the amount of power-up with one.
			_numPower++;

			// Remove the requested power-up.
			PowerUps.Remove (_power);
		}

		// Add the requested power-up.
		PowerUps.Add (_power, _numPower);
	}

	bool RemovePowerUp (string _power)
	{
		int _numPower = 0;

		// Try to retrieve the power-up requested and store its value.
		if (PowerUps.TryGetValue (_power, out _numPower)) {
			// Decrease the amount of power-up with one.
			_numPower--;

			// Remove the requested power-up.
			PowerUps.Remove (_power);
		} else
            // Power-up not found, return false.
            return false;

		// When the power-up is not depleted, add its updated amount.
		if (_numPower != 0)
			PowerUps.Add (_power, _numPower);

		return true;
	}

	void UsePowerUp (string _power)
	{
		Action _usablePower;

		// Check if power-up can be used.
		if (RemovePowerUp (_power)) {
			// YES? EXECUTE!!!
			Powers.TryGetValue (_power, out _usablePower);

			_usablePower ();
		}
	}

	void Jump ()
	{
		Debug.Log ("Jump!");

		// Jump based on table rotation.
		GetComponent<Rigidbody> ().AddForce (GameObject.Find ("Table").transform.up * Physics.gravity.y * -150);
	}
}
