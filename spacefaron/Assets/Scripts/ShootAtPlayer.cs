using UnityEngine;
using System.Collections;

public class ShootAtPlayer : MonoBehaviour {


	public float playerRange;
	public GameObject AlienBullet;
	public Player player;
	public Transform launchPoint;
	public float waitBetweenShots;
	private float shotCounter;



	// Use this for initialization
	void Start () {

		player = FindObjectOfType<Player> ();
		shotCounter = waitBetweenShots;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		shotCounter -= Time.deltaTime;

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
		{
			Instantiate(AlienBullet,launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}
		else if(player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
		{
			Instantiate(AlienBullet,launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}


	}
}
