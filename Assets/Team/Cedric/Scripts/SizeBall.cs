using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeBall : MonoBehaviour
{
	#region Public Members

		public GameObject m_player;
		public Text m_textSizePlayer;

		protected static float m_sizeTotalBall;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			m_ballInfo = new BallInfo();
			m_playerCollider = m_player.GetComponent<Collider>();
		}

		void Update()
		{
			m_sizeTotalBall = m_ballInfo.GetSizeObject(m_playerCollider.bounds.size);
			m_textSizePlayer.text = m_sizeTotalBall.ToString();
		}

	#endregion

	#region Tools Debug And Utility

	#endregion

	#region Private and Protected Members

		private BallInfo m_ballInfo;
		private Collider m_playerCollider;

	#endregion
}
