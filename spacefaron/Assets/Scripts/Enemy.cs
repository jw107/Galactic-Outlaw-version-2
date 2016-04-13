using UnityEngine;
using System.Collections;
using Pathfinding;

public class Enemy : MonoBehaviour {


    [System.Serializable]
    public class EnemyStats
    {

        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 10;

        public void init()
        {
            curHealth = maxHealth;

        }

    }
    public Transform deathParticles;
    public EnemyStats Stats = new EnemyStats();
	private EnemyAI enemyAI;
	public Transform Target;
	public float playerDistance;
 

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {

		enemyAI = GetComponent<EnemyAI> ();



        Stats.init();

        if(statusIndicator != null)
        {
            statusIndicator.SetHealth(Stats.curHealth, Stats.maxHealth);
        }

        if(deathParticles == null)
        {
            Debug.LogError("no death particles found");
        }

    }

	void Update()
	{
		if (Target == null) 
		{
			GameObject player = GameObject.FindGameObjectWithTag ("FlyingEnemy");
			if (player != null)
				Target = player.transform;
		}

		playerDistance = Vector3.Distance(Target.position, transform.position);

		if (playerDistance < 20f) {

			enemyAI.enabled = true;

		} 
		else 
		{
			enemyAI.enabled = false;

		}


	}



    void OnCollisionEnter2D(Collision2D _colInfo)
    {
     
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
          
            _player.DamagePlayer(Stats.damage);
          

        }
    }

    public void DamageEnemy(int damage)
    {

        Stats.curHealth -= damage;

        if (Stats.curHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(Stats.curHealth, Stats.maxHealth);
        }
    }


}
