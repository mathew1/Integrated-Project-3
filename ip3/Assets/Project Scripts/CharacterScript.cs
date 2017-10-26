using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public float jumpForce = 400f; 
	private bool isGrounded = false;
	public int ran;
	public GameObject ob1;
	public GameObject ob2;
	public GameObject ob3;
	public GameObject ob4;
	public GameObject ob5;
	public GameObject player;
	public Animator anim;
	
	//private bool isFalling = false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	// Player movement
	public void Move(float move, bool jump)
	{
		anim.SetFloat("Speed", Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);
		
		
		//Player Jumping
		if (jump && isGrounded == true) {
			
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			anim.SetTrigger("Jump");
			isGrounded = false;
			Debug.Log("Player Jumped");
			
		}
	}
	// Confirming that the player is on the ground again so that he can jump
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "platformFixed"){
			
			isGrounded = true;
			Debug.Log("Player Landed");
		}
		// markers are used to load the next platform generation
		if(collision.gameObject.tag == "marker"){
			numgenerator ();
			
			switch(ran){
			case 1: Debug.Log ("case 1");
				Instantiate (ob1, (new Vector3((player.transform.position.x + 210.5f),(-0.8f),0.0f)), Quaternion.identity);
				break;
			case 2: Debug.Log ("case 2");
				Instantiate (ob2, (new Vector3((player.transform.position.x + 210.5f),(-0.8f),0.0f)), Quaternion.identity);
				break;
			case 3: Debug.Log ("case 3");
				Instantiate (ob3, (new Vector3((player.transform.position.x + 210.5f),(-0.8f),0.0f)), Quaternion.identity);
				break;
			case 4: Debug.Log ("case 4");
				Instantiate (ob4, (new Vector3((player.transform.position.x + 210.5f),( -0.8f),0.0f)), Quaternion.identity);
				break;
			case 5: Debug.Log ("case 5");
				Instantiate (ob5, (new Vector3((player.transform.position.x + 210.5f),( -0.8f),0.0f)), Quaternion.identity);
				break;
			}
			DestroyObject(collision.gameObject);
			Debug.Log("marker detected");
		}
	}
	public void numgenerator(){
		ran = Random.Range (1, 5);
	}
}

