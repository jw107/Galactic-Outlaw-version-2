using UnityEngine;
using System.Collections;

public class FlyingShoter : MonoBehaviour {

	public float playerDistance;
	public GameObject AlienBullet;
	public Player player;
	public Transform launchPoint;
	public float waitBetweenShots;
	private float shotCounter;
	public Transform Target;
	
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<Player> ();
		shotCounter = waitBetweenShots;
		
	}
	
	// Update is called once per frame
	void Update () 

	{

		
		shotCounter -= Time.deltaTime;
		if (Target == null) 
		{
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if (player != null)
				Target = player.transform;
		}

		playerDistance = Vector3.Distance(Target.position, transform.position);
		
		if (playerDistance < 10f && shotCounter < 0) {
			
			Instantiate(AlienBullet,launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
			
		} 




		
	
		
		
		
	}
}
