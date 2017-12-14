using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTheBall : Ball
{
	#region Public Members

		// Get the Player's object
		public Transform m_objectPlayer;
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
			if(m_objectPlayer == null)
				m_objectPlayer = GetComponent<Transform>();
			if(m_sphereColliderPlayer == null)
				m_sphereColliderPlayer = GetComponent<SphereCollider>();

			// Get the volume of the Player
			m_objectCollider_size = GetSizeObject(m_collider.bounds.size);

			m_speedGrow *= 100f;
		}

		void Update()
		{
		}

		void OnCollisionEnter(Collision col)
		{
			// Get again the volume of the Player
			m_objectCollider_size = GetSizeObject(m_collider.bounds.size);
			// Get the Collider of the object touched
			Collider collider = col.gameObject.GetComponent<Collider>();
			// Get the volume of the object touched
			float col_size = GetSizeObject(collider.bounds.size);
			// IF the object touched is smaller than the Player
			if(col_size < m_objectCollider_size)
			{
				// Grow the Player's scale
				float addScale = col_size / m_speedGrow;
				// transform.localScale += new Vector3(addScale,addScale,addScale);
				m_sphereColliderPlayer.radius += addScale;
				// Call StickObject function
				StickObject(col.gameObject, col_size);
			}
		}

	#endregion

	#region Tools Debug And Utility

		private float GetSizeObject(Vector3 _vec3)
		{
			// Return the volume
			return _vec3.x * _vec3.y * _vec3.z;
		}

		private void StickObject(GameObject _obj, float _colSize)
		{
			// Stick the object touched
			_obj.transform.parent = m_objectPlayer;
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
							Destroy(comp);
			}
		}

	#endregion

	#region Private and Protected Members

		private float m_objectCollider_size;

	#endregion
}
