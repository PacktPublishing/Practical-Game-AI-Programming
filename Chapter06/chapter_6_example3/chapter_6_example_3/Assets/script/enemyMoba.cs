using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoba : MonoBehaviour {

	public float speed;
	public int health;
	public float speedTurn;

	public bool Team1;
	public bool Team2;

	public bool Top;
	public bool Middle;
	public bool Bottom;

	public Transform [] _Top;
	public Transform [] _Middle;
	public Transform [] _Bot;

	private Transform target;
	private int wavepointIndex = 0;


	void Start ()
	{
		if(Team1 == true)
		{
			if(Top == true)
			{
				target = _Top[0];
			}

			if(Middle == true)
			{
				target = _Middle[0];
			}

			if(Bottom == true)
			{
				target = _Bot[0];
			}
		}

		if(Team2 == true)
		{
			if(Top == true)
			{
				target = _Top[0];
			}

			if(Middle == true)
			{
				target = _Middle[0];
			}

			if(Bottom == true)
			{
				target = _Top[0];
			}
		}
		speed = 10f;
		speedTurn = 0.2f;
	}

	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if(Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, speedTurn, 0.0F);

		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void GetNextWaypoint()
	{
		if(Team1 == true)
		{
			if(Top == true)
			{
				if(wavepointIndex >= _Top.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Top[wavepointIndex];
			}

			if(Middle == true)
			{
				if(wavepointIndex >= _Middle.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Middle[wavepointIndex];
			}

			if(Bottom == true)
			{
				if(wavepointIndex >= _Bot.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Bot[wavepointIndex];
			}
		}

		if(Team2 == true)
		{
			if(Top == true)
			{
				if(wavepointIndex >= _Top.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Top[wavepointIndex];
			}

			if(Middle == true)
			{
				if(wavepointIndex >= _Middle.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Middle[wavepointIndex];
			}

			if(Bottom == true)
			{
				if(wavepointIndex >= _Bot.Length - 1)
				{
					Destroy(gameObject);
					return;
				}

				wavepointIndex++;
				target = _Bot[wavepointIndex];
			}
		}
	} 

}

