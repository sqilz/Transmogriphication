using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]

public class EnemyAI : MonoBehaviour {
	//what to chase
	public Transform target;
	//hwo many times each second we will update our path
	public float updateRate = 2f;
	// caching
	private Seeker seeker;
	private Rigidbody2D rb;

	// The calculated path
	public Path path;

	// The AI speed per second
	public float speed =  300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool PathIsEnded = false;
	//Max distance from AI to a waypoint for it to continue to the next waypoint
	public float nextWaypoint = 3;
	//the waypont we are currently moving towards
	private int currentWaitPoint = 0;

	private bool searchingForPlayer = false;
	void Start()
	{
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();

		if(target == null)
		{
			if(!searchingForPlayer)
			{
				searchingForPlayer = true;
				StartCoroutine (searchForPlayer());
			}
			return;
		}
		// start a new path to the target position, return result to the onpathcomplete method
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		StartCoroutine(UpdatePath());
	}
	IEnumerator searchForPlayer()
	{
		GameObject sResult = GameObject.FindGameObjectWithTag("Player");
		if(sResult == null)
		{
			yield return new WaitForSeconds ( 0.5f );
			StartCoroutine (searchForPlayer());
		}
		else 
		{
			target = sResult.transform;
			searchingForPlayer = false;
			StartCoroutine (UpdatePath());
			return false;
		}
	}
	IEnumerator UpdatePath()
	{
		if(target == null)
		{
			if(!searchingForPlayer)
			{
				searchingForPlayer = true;
				StartCoroutine (searchForPlayer());
			}
			return false;
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds(1f/updateRate);
		StartCoroutine(UpdatePath());
	}
	public void OnPathComplete (Path p)
	{
		Debug.Log("We got a pth did it have an erro?" + p.error);

		if(!p.error)
		{
			path = p;
			currentWaitPoint = 0;
		}
	}
	void FixedUpdate()
	{
		if(target == null)
		{
			if(!searchingForPlayer)
			{
				searchingForPlayer = true;
				StartCoroutine (searchForPlayer());
			}
			return;
		}
		//TODO: Always look at player?
		if(path == null)
		{
			return;
		}
		if(currentWaitPoint >= path.vectorPath.Count)
		{
			if (PathIsEnded)
				return;

			Debug.Log("End of Path is reached.");
			PathIsEnded = true;
			return;
		}
		PathIsEnded = false;

		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaitPoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		// move the AI
		rb.AddForce (dir, fMode);
		float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaitPoint]);
		if(dist < nextWaypoint)
		{
			currentWaitPoint++;
			return;
		}
	}
}
