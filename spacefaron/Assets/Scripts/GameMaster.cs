using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;
	private int deathcounter = 0;
    

    void Start()
	{
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		}
	}

    public Transform spawnPoint;
    public Transform playerPrefab;
    public Transform spawnPrefab;
    public int spawnDelay = 2;
	public Transform mainCamera;
	public Transform CameraRespawn;
	public Player Player;
	public StatusIndicator statusindicator;
	private int temp = -5;




    public IEnumerator RespawnPlayer()
    {
		deathcounter = deathcounter + 1;
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(clone, 3f);
		CameraRespawn.position = spawnPoint.position;
		mainCamera.position = CameraRespawn.position;
		Player.Stats.init ();
		statusindicator.SetHealth (1,1);

		if (deathcounter >= 3) 
		{
			// load game other scene
		}

	}
		




    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);

    }

    public void _KillEnemy(Enemy _enemy)
    {
        Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity);
        Destroy(_enemy.gameObject);
    }

}
