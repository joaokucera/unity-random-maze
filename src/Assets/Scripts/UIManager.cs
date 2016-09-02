using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	[SerializeField] private Image m_panel;
	[SerializeField] private Text m_textUI;

	private string[] m_messages = { "Get Ready!", "Get Set!", "Go!", "" };
	private int m_index = 0;

	public void InterateTextMessage ()
	{
		if (m_index >= m_messages.Length) 
		{
			return;
		}

		m_textUI.text = m_messages [m_index];

		if (m_index == m_messages.Length - 1) 
		{
			m_panel.enabled = false;
		}

		m_index++;
	}
}