using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MarbleController : MonoBehaviour
{
	public bool DirectControl = false;

	// A place to save the score of the player, this is hidden from the editor.
	[HideInInspector]
	public static int PlayerScore;

	private Dictionary<string, int> PowerUps;
	private Dictionary<string, Action> Powers;

	public List<string> TableNames;

	private bool _grounded = false;
	private bool _jumping = false;

	public float MoveForce = 20f;

	void Start ()
	{
		// Set score to zero when this object is created.
		PlayerScore = 0;

		if (TableNames.Count == 0)
			TableNames.Add("TableTop");

		// We can not jump yet!
		_grounded = false;
		_jumping = false;

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
		Debug.Log (_grounded);
		Debug.Log (_jumping);
	}

	void FixedUpdate ()
	{
		if (Input.GetButtonDown ("Jump") && _grounded && !_jumping) {
			UsePowerUp ("Jump");
		}

		/*if (Input.GetButtonDown("Fire2") && _grounded)
            UsePowerUp("Boost");*/

		if (DirectControl && _grounded && !_jumping)
		{
			if (Input.GetButton("Horizontal"))
			{
				GetComponent<Rigidbody> ().AddForce (transform.forward * MoveForce * Input.GetAxis("Horizontal"));
			}

			if (Input.GetButton("Vertical"))
			{
				GetComponent<Rigidbody> ().AddForce (transform.right * MoveForce * -Input.GetAxis("Vertical"));
			}
		}
	}

	void OnCollisionEnter (Collision _collision)
	{
	}

	void OnCollisionStay (Collision _collision)
	{
		foreach (string _tableName in TableNames)
			if (_collision.gameObject.name == _tableName)
				_grounded = true;
	}

	void OnCollisionExit (Collision _collision)
	{
		foreach (string _tableName in TableNames)
			if (_collision.gameObject.name == _tableName)
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
		if (RemovePowerUp (_power))
		{
			// YES? EXECUTE!!!
			Powers.TryGetValue (_power, out _usablePower);

			_usablePower ();
		}
	}

	void Jump ()
	{
		_jumping = true;

		GetComponent<Rigidbody> ().AddForce (transform.up * Physics.gravity.y * -(MoveForce * 4f));

		Invoke ("StopJumping", 0.1f);
	}

	void StopJumping ()
	{
		_jumping = false;
	}
}
