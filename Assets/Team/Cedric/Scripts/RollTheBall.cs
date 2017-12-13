using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollTheBall : MonoBehaviour
{
	#region Public Members

		public Rigidbody m_rigidbody;
		public float m_speedBall = 5f;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			if( m_rigidbody == null )
			{
				m_rigidbody = GetComponent<Rigidbody>();
			}
		}
	
		void FixedUpdate()
		{
			MoveBall();
		}

	#endregion

	#region Tools Debug And Utility

		private void MoveBall()
		{
			if(Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
			{
				float SpeedV = Input.GetAxisRaw("Vertical")*m_speedBall;
				float SpeedH = Input.GetAxisRaw("Horizontal")*m_speedBall;
				m_rigidbody.AddForce(SpeedH,0f,SpeedV);
			}
		}

	#endregion

	#region Private and Protected Members

	#endregion
}
