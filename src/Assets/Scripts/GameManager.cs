using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Utility;

public class GameManager : MonoBehaviour 
{
	[SerializeField] private UIManager m_uiManager;
	[SerializeField] private Maze m_mazePrefab;
	[SerializeField] private ModernPlayer m_playerPrefab;
	[SerializeField] private Enemy m_enemyPrefab;

	private Maze m_mazeInstance;
	private ModernPlayer m_playerInstance;
	private Enemy [] m_enemiesInstances;

	private void Start () 
	{
		StartCoroutine (BeginGame());
	}
	
	private void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			RestartGame();
		}
	}

	private IEnumerator BeginGame () 
	{
		m_mazeInstance = Instantiate (m_mazePrefab) as Maze;
		yield return StartCoroutine(m_mazeInstance.Generate());

		var wait = new WaitForSeconds (1.5f);

		m_uiManager.InterateTextMessage ();
		yield return wait;

		CreateEnemies ();

		m_uiManager.InterateTextMessage ();
		yield return wait;

		CreatePlayer ();

		m_uiManager.InterateTextMessage ();
		yield return wait;

		m_uiManager.InterateTextMessage ();
	}

	private void CreatePlayer ()
	{
		var startPosition = m_mazeInstance.GetCell (m_mazeInstance.RandomCoordinates).transform.localPosition;
		startPosition.y += .1f;

		m_playerInstance = Instantiate (m_playerPrefab) as ModernPlayer;
		m_playerInstance.transform.localPosition = startPosition;
	}

	private void CreateEnemies ()
	{
		m_enemiesInstances = new Enemy [4];

		for (int i = 0; i < m_enemiesInstances.Length; i++)
		{
			var startPosition = m_mazeInstance.GetCell (m_mazeInstance.RandomCoordinates).transform.localPosition;
			startPosition.y += .1f;

			m_enemiesInstances [i] = Instantiate (m_enemyPrefab) as Enemy;
			m_enemiesInstances [i].transform.localPosition = startPosition;
			m_enemiesInstances [i].Direction = (MazeDirection)i;
		}
	}

	private void RestartGame () 
	{
		StopAllCoroutines ();
		Destroy (m_mazeInstance.gameObject);

		if (m_playerInstance != null) 
		{
			Destroy (m_playerInstance.gameObject);
		}

		StartCoroutine (BeginGame ());
	}
}