using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
	public Transform[] backgrounds; //list of all the backgrounds and foregrounds to be parallax
	private float[] parallaxScales;  //proportion of the cameras movement to move the background by
	public float smoothing = 1f;	//how smooth the parallaxing is going to be but it needs to have a value above zero
	private Transform cam;  //refference to the main cameras transform
	private Vector3 previousCamPosition;  //stores the position of the camera in the previous frame
	
	
	
	//Awake is called before start function but after the gameobjects are set up
	//Great for reference
	void Awake(){
		//set up reference for the camera
		cam = Camera.main.transform;
		
	}
	
	// Use this for initialization
	void Start () {
		//store the previous frame at the current frames camera position
		previousCamPosition = cam.position;
		
		//assigning corresponding parallax scales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the opposite of the camera movement becuase the previous frame multiplied bu the scale
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales [i];
			
			//set Target x position which is the current positon plus the parallax
			float backgroundTargetPositionX = backgrounds[i].position.x + parallax;
			//create a target position which is the background current position wotj ots target x position
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			//fade between the current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing*Time.deltaTime);
			
		}
		//set the previous cam position to the cameras positon at the end of the frame
		previousCamPosition = cam.position;
	}
}
