using UnityEngine;

public abstract class MazeCellEdge : MonoBehaviour 
{
	protected MazeCell m_cell, m_otherCell;
	protected MazeDirection m_direction;

	public MazeCell OtherCell { get { return m_cell; } }

	public virtual void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) 
	{
		m_cell = cell;
		m_otherCell = otherCell;
		m_direction = direction;

		cell.SetEdge(direction, this);

		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = direction.ToRotation();
	}

	public virtual void OnPlayerEntered () {}

	public virtual void OnPlayerExited () {}
}