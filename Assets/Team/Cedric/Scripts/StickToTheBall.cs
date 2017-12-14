using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTheBall : Ball
{
	#region Public Members

		// Get the Player's object
		public Transform m_objectParent;
		// Get the Player's Sphere Collider
		public SphereCollider m_sphereColliderPlayer;
		// Vitesse de grossissement
		[Range(1f,10f)]
		public float m_speedGrow = 10f;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			// New Instance BallInfo
			m_ballInfo = new BallInfo();

			/*if(m_objectParent == null)
				m_objectParent = GetComponent<Transform>();
			if(m_sphereColliderPlayer == null)
				m_sphereColliderPlayer = GetComponent<SphereCollider>();*/

			// Get the volume of the Player
			//m_objectCollider_size = m_ballInfo.GetSizeObject(m_collider.bounds.size);

			m_speedGrow *= 10000f;
		}

		void OnCollisionEnter(Collision col)
		{
			// Get again the volume of the Player
			m_objectCollider_size = m_ballInfo.GetSizeObject(m_collider.bounds.size);
			// Get the Collider of the object touched
			Collider collider = col.gameObject.GetComponent<Collider>();
			// Get the volume of the object touched
			float col_size = m_ballInfo.GetSizeObject(collider.bounds.size);
			// IF the object touched is smaller than the Player
			if(col_size < m_objectCollider_size)
			{
                collider.isTrigger = true;
				// Grow the Player's scale
				float addScale = col_size / m_speedGrow;
				m_sphereColliderPlayer.radius += addScale;
				// Call StickObject function
				StickObject(col.gameObject, col_size);
			}
		}

	#endregion

	#region Tools Debug And Utility

		private void StickObject(GameObject _obj, float _colSize)
		{
			// Stick the object touched
			_obj.transform.parent = m_objectParent;
			// Destroy All Components of the object touched
			DestroyComponents(_obj.GetComponents<Component>());
		}

		private void DestroyComponents(Component[] _objComponents)
		{
			foreach(var comp in _objComponents)
			{
				// IF the Component is not :
				// Transform, MeshFilter, MeshRenderer
				if(!(comp is Transform))
					if(!(comp is MeshFilter))
						if(!(comp is MeshRenderer))
                            if(!(comp is Collider))
							    Destroy(comp);
			}
		}

	#endregion

	#region Private and Protected Members

		private float m_objectCollider_size;
		private BallInfo m_ballInfo;

	#endregion
}
