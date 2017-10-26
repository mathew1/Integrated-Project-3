using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void changeScene( int sceneToChangeTo )
	{
		Application.LoadLevel (sceneToChangeTo);
	}
   


}
