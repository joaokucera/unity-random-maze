using UnityEngine;
using System.Collections;

public class CheckCollision : MonoBehaviour 
{
	private const string MazeTag = "Maze";

	private Enemy m_enemy;

	public void Initialize (Enemy enemy)
	{
		m_enemy = enemy;
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.CompareTag (MazeTag)) 
		{
			m_enemy.DoCollision ();
		}
	}
}