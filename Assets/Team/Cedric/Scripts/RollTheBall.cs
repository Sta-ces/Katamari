using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : Ball
{
	#region Public Members

		public float m_speedBall = 5f;
		[Range(0f,1f)]
		public float m_brakeBall = 0.75f;

	#endregion

	#region Public void

	#endregion

	#region System
	
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
				float SpeedZ = Input.GetAxisRaw("Vertical")*m_speedBall;
				float SpeedX = Input.GetAxisRaw("Horizontal")*m_speedBall;
				float SpeedY = m_rigidbody.velocity.y;
				m_rigidbody.AddForce(SpeedX,SpeedY,SpeedZ);
			}
			m_rigidbody.angularDrag = m_rigidbody.angularVelocity.magnitude * m_brakeBall;
		}

	#endregion

	#region Private and Protected Members

	#endregion
}
