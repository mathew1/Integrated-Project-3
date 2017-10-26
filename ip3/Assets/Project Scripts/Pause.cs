using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	private bool paused = false;
	
	public void pause ()
	{
		if (paused == false)
		{
			paused = true;
			Time.timeScale = 0;
			Debug.Log ("Game is Paused");
			
		}
		else if (paused == true)
		{
			paused = false;
			Time.timeScale = 1;
			
		}
	}
}
