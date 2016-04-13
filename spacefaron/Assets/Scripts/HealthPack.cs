using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D _colInfo)
	{


		
		Player _player = _colInfo.collider.GetComponent<Player>();
		if (_player != null)
		{
			Destroy(gameObject);
			_player.DamagePlayer(-50);


		}
	}
}
