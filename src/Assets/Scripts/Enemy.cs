using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	[HideInInspector] public MazeDirection Direction;

	private Rigidbody m_rigidbody;
	private Vector3 m_movement;
	private float m_moveSpeed = 1f;
	private bool m_hasCollided = false;

	void Start ()
	{
		m_rigidbody = GetComponentInChildren<Rigidbody> ();

		var checkCollision = GetComponentInChildren<CheckCollision> ();
		checkCollision.Initialize (this);
	}

	void FixedUpdate ()
	{
		if (m_hasCollided) 
		{
			return;
		}

		float h = 0, v = 0;
		switch (Direction) 
		{
			case MazeDirection.North:
				h = 0;
				v = 1;
				break;
			case MazeDirection.East:
				h = -1;
				v = 0;
				break;
			case MazeDirection.South:
				h = 0;
				v = -1;
				break;
			case MazeDirection.West:
				h = 1;
				v = 0;
				break;
		}

		m_movement = new Vector3 (h, 0, v);

		m_rigidbody.velocity = m_movement * m_moveSpeed;
	}

	public void DoCollision ()
	{
		if (m_hasCollided) 
		{
			return;
		}

		StartCoroutine (WaitToMoveAgain ());
	}

	IEnumerator WaitToMoveAgain ()
	{
		m_hasCollided = true;
		m_rigidbody.velocity = Vector3.zero;
		m_movement = Vector3.zero;

		yield return new WaitForSeconds (1.5f);

		switch (Direction)
		{
			case MazeDirection.North:
				Direction = MazeDirection.South;
				break;
			case MazeDirection.East:
				Direction = MazeDirection.West;
				break;
			case MazeDirection.South:
				Direction = MazeDirection.North;
				break;
			case MazeDirection.West:
				Direction = MazeDirection.East;
				break;
		}

		m_hasCollided = false;
	}
}