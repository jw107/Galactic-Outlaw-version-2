using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {


    public Enemy EnemyScript;
    public float speed;
    public Player player;



    // Use this for initialization
    void Start () {


        player = FindObjectOfType<Player>();

        if (player.transform.localRotation.y != 0)
        {
            speed = -speed;
        }

    }

    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {

        Destroy(gameObject);

		Enemy _Enemy = _colInfo.collider.GetComponent<Enemy>();
		if (_Enemy != null)
		{
			
			_Enemy.DamageEnemy(50);

		}


    }


}
