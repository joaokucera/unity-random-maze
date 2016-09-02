using UnityEngine;

public class MazeGate : MazePassage 
{
	private MazeGate OtherSideOfWindow 
	{
		get 
		{
			return m_otherCell.GetEdge (m_direction.GetOpposite()) as MazeGate;
		}
	}

	public override void Initialize (MazeCell primary, MazeCell other, MazeDirection direction) {
		base.Initialize(primary, other, direction);
	
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			child.GetComponent<Renderer> ().material = m_cell.Room.settings.wallMaterial;
		}
	}

	public override void OnPlayerEntered () {
		OtherSideOfWindow.m_cell.Room.Show();
	}

	public override void OnPlayerExited () {
		OtherSideOfWindow.m_cell.Room.Hide();
	}
}