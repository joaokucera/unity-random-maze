using UnityEngine;

public class MazeDoor : MazePassage 
{
	private static Quaternion NormalRotation = Quaternion.Euler (0f, -90f, 0f), mirroredRotation = Quaternion.Euler (0f, 90f, 0f);

	[SerializeField] private Transform m_hinge;

	private bool m_isMirrored;

	private MazeDoor OtherSideOfDoor 
	{
		get 
		{
			return m_otherCell.GetEdge (m_direction.GetOpposite()) as MazeDoor;
		}
	}
	
	public override void Initialize (MazeCell primary, MazeCell other, MazeDirection direction) 
	{
		base.Initialize(primary, other, direction);

		if (OtherSideOfDoor != null) 
		{
			m_isMirrored = true;
			m_hinge.localScale = new Vector3(-1f, 1f, 1f);
			Vector3 p = m_hinge.localPosition;
			p.x = -p.x;
			m_hinge.localPosition = p;
		}

		for (int i = 0; i < transform.childCount; i++) 
		{
			Transform child = transform.GetChild(i);
			if (child != m_hinge) 
			{
				child.GetComponent<Renderer>().material = m_cell.Room.settings.wallMaterial;
			}
		}
	}

	public override void OnPlayerEntered () 
	{
		OtherSideOfDoor.m_hinge.localRotation = m_hinge.localRotation = m_isMirrored ? mirroredRotation : NormalRotation;
		OtherSideOfDoor.m_cell.Room.Show();
	}
	
	public override void OnPlayerExited () 
	{
		OtherSideOfDoor.m_hinge.localRotation = m_hinge.localRotation = Quaternion.identity;
		OtherSideOfDoor.m_cell.Room.Hide();
	}
}