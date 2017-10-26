using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "die") {
			Application.LoadLevel ("DeathScene");
		}


		if (collision.gameObject.tag == "die1") {
			Application.LoadLevel ("DeathScene2");
		}

		if (collision.gameObject.tag == "die2") {
			Application.LoadLevel ("DeathScene3");
		}


	}


}
