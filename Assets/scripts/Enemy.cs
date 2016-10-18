using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	[System.Serializable]
	public class EnemyStats 
	{
		public int Health = 100;
	}
	
	public EnemyStats stats = new EnemyStats();
	
		
	public void DamageEnemy (int damage)
	{
		stats.Health -= damage;
		if(stats.Health <= 0)
		{
			GameMaster.KillEnemy(this);
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{	
		if(col.gameObject.tag == "Player")
		{
			//TODO: ADD ENEMY KILL SOUND
			DamageEnemy(999);
		}
	}
}
