using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
	#region Public Members

		protected static Collider m_collider;
		protected static Rigidbody m_rigidbody;

        public GameObject m_player;
        public GameObject m_objectToMove;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			m_collider = m_player.GetComponent<SphereCollider>();
        
			m_rigidbody = m_objectToMove.GetComponent<Rigidbody>();
		}

	#endregion

	#region Tools Debug And Utility

	#endregion

	#region Private and Protected Members

	#endregion
}
