using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTheBall : Ball
{
	#region Public Members

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			m_collider_size = GetSizeObject(m_collider.bounds.size);
		}

		void OnCollisionEnter(Collision col)
		{
			Collider collider = col.gameObject.GetComponent<Collider>();
			float col_size = GetSizeObject(collider.bounds.size);
			if(col_size < m_collider_size)
			{
				Debug.Log("Small - Stick");
			}
		}

	#endregion

	#region Tools Debug And Utility

		private float GetSizeObject(Vector3 vec3)
		{
			return vec3.x * vec3.y * vec3.z;
		}

	#endregion

	#region Private and Protected Members

		private float m_collider_size;

	#endregion
}
