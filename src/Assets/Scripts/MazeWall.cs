using UnityEngine;

public class MazeWall : MazeCellEdge 
{
	[SerializeField] private Transform m_wall;

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) 
	{
		base.Initialize (cell, otherCell, direction);

		m_wall.GetComponent<Renderer>().material = cell.Room.settings.wallMaterial;
	}
}