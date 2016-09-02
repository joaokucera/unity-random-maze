using UnityEngine;

public class ModernPlayer : MonoBehaviour 
{
	private Rigidbody m_rigidbody;
	private Vector3 m_movement;
	private float m_moveSpeed = 2.5f;
	private float m_tilt = 5f;

	void Start ()
	{
		m_rigidbody = GetComponentInChildren<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		m_movement = new Vector3 (h, 0, v);
	
		m_rigidbody.velocity = m_movement * m_moveSpeed;
		m_rigidbody.rotation = Quaternion.Euler (0f, 0f, m_rigidbody.velocity.x * -m_tilt);
	}
}