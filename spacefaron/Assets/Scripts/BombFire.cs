using UnityEngine;
using System.Collections;

public class BombFire : MonoBehaviour {

	
	public float speed;
	public Player player;
	public float rotationSpeed;
	private Rigidbody2D myrigidbody2D;
	
	
	void Start()
	{
		player = FindObjectOfType<Player> ();
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		
	
		
	}
	
	
	void Update()
	{
		
	//	GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.x);
		
		myrigidbody2D.angularVelocity = rotationSpeed;
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		Player _player = other.GetComponent<Player>();
		if (_player != null)
		{
			
			_player.DamagePlayer(10);
			Destroy (gameObject);
		}
		
		
	}

}
