using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
	#region Public Members

		protected static Collider m_collider;
		protected static Rigidbody m_rigidbody;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			if(m_collider == null)
				m_collider = GetComponent<SphereCollider>();

			if( m_rigidbody == null )
				m_rigidbody = GetComponent<Rigidbody>();
		}

	#endregion

	#region Tools Debug And Utility

	#endregion

	#region Private and Protected Members

	#endregion
}
