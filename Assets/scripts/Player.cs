using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	[System.Serializable]
	public class PlayerStats 
	{
		public int Health = 100;
	}

	public PlayerStats playerStats = new PlayerStats();

	public int fallBoundary = -20;

	Enemy enemy;

	void Update()
	{
		if(transform.position.y <= fallBoundary)
		{
			DamagePlayer (999999);
		}
	}

	public void DamagePlayer (int damage)
	{
		playerStats.Health -= damage;
		if(playerStats.Health <= 0)
		{
			GameMaster.KillPlayer(this);
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{	
		if(col.gameObject.tag == "Enemy")
		{
			//TODO: ADD ENEMY KILL SOUND
			DamagePlayer(20);
		
		}
	}

}
