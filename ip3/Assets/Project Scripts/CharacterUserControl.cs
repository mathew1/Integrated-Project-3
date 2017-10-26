using UnityEngine;
using System.Collections;


[RequireComponent(typeof (CharacterScript))]
public class CharacterUserControl : MonoBehaviour {

	private CharacterScript character;
	private bool jump;

	private void Awake()
	{
		character = GetComponent<CharacterScript>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!jump)
			// Read the jump input in Update so button presses aren't missed.
			jump = Input.GetMouseButtonDown(0);
	}
	private void FixedUpdate()
	{
		// Read the inputs.
		
		// Pass all parameters to the character control script.
		character.Move(1, jump);
		jump = false;
	}
}
