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

				CameraRotation(SpeedX);
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

		private void CameraRotation(float _horizontal)
		{
			// Vector3 camForw = Camera.main.transform.forward;
			// Vector3 gamObjForw = m_rigidbody.transform.forward;
			// Camera.main.transform.rotation = Quaternion.Euler(gamObjForw) * Quaternion.Euler(camForw);
			// Debug.Log(gamObjForw);
			// Quaternion quat = Quaternion.Euler(gamObjForw);
			// Debug.Log(gamObjForw);
			// Debug.Log(quat);
			// Camera.main.transform.rotation = quat;
			// Vector3 camForw = Camera.main.transform.forward;
			// Vector3 destination = new Vector3(_horizontal, 0f, _vertical);
			// Quaternion quatDestination = Quaternion.Euler(destination);
			// Quaternion quatCamForw = Quaternion.Euler(camForw) * quatDestination;
			// Camera.main.transform.rotation = Quaternion.Slerp(quatCamForw, quatDestination, m_speedBall);
			/*Vector3 camForw = Camera.main.transform.forward;
			Vector3 gamObjForw = m_rigidbody.transform.forward;
			gamObjForw = camForw;*/
			Quaternion quat = Quaternion.Euler(m_speedBall * _horizontal * Time.deltaTime);
			Camera.main.transform.rotation.y = quat;
		}

	#endregion

	#region Private and Protected Members

	#endregion
}
