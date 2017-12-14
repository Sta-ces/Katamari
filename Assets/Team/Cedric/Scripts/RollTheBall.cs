using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : Ball
{
	#region Public Members

		[Range(10f,60f)]
		public float m_speedBall = 30f;
		[Range(1f,10f)]
		public float m_brakeBall = 2.5f;
		[Range(5f,20f)]
		public float m_superSpeedBall = 10f;

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
			// Push
			if(Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
			{
				float speed;
				if(Input.GetButton("Jump"))
					speed = 10f * m_speedBall;
				else
					speed = m_speedBall;

				SpeedZ = Input.GetAxisRaw("Vertical") * speed;
				SpeedX = Input.GetAxisRaw("Horizontal") * speed;
			}
			// Brake
			else{
				SpeedZ = -m_brakeBall * m_rigidbody.velocity.z;
				SpeedX = -m_brakeBall * m_rigidbody.velocity.x;
			}
			// If it's in the air
			RaycastHit hitInfo;
			if(Physics.Raycast(m_rigidbody.transform.position,Vector3.down,out hitInfo))
			{
				float distanceGround = (hitInfo.distance - (m_rigidbody.transform.localScale.y * 0.5f));
				if(distanceGround != 0)
					SpeedY = m_rigidbody.velocity.y * 0.5f;
			}
			// Set to movement
			Vector3 movement = new Vector3(SpeedX,SpeedY,SpeedZ);
			m_rigidbody.AddForce(movement);
		}

	#endregion

	#region Private and Protected Members

	#endregion
}
