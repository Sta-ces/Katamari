using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : Ball
{
	#region Public Members

		public float m_speedBall = 5f;
		[Range(1f,10f)]
		public float m_brakeBall = 1f;

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
			float SpeedZ = m_rigidbody.velocity.z;
			float SpeedX = m_rigidbody.velocity.x;
			float SpeedY = m_rigidbody.velocity.y;
			if(Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
			{
				SpeedZ = Input.GetAxisRaw("Vertical") * m_speedBall;
				SpeedX = Input.GetAxisRaw("Horizontal") * m_speedBall;
			}
			else{
				SpeedZ = -m_brakeBall * m_rigidbody.velocity.z;
				SpeedX = -m_brakeBall * m_rigidbody.velocity.x;
			}
			Vector3 movement = new Vector3(SpeedX,SpeedY,SpeedZ);
			m_rigidbody.AddForce(movement);
		}

	#endregion

	#region Private and Protected Members

	#endregion
}
