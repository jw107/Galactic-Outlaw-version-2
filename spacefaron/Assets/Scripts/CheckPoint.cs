using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {


	public GameMaster gm;

	// Use this for initialization
	void Start () {

		gm = FindObjectOfType<GameMaster> ();
	
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("helllo");
		if (other.tag == "Player") 
		{
			Debug.Log ("helllo");
			gm.spawnPoint.transform.position = other.transform.position;
		}
		
		
	}
}
