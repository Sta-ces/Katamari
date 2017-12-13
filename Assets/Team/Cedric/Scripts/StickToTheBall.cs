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
				StickObject(col.gameObject);
			}
		}

	#endregion

	#region Tools Debug And Utility

		private float GetSizeObject(Vector3 _vec3)
		{
			return _vec3.x * _vec3.y * _vec3.z;
		}

		private void StickObject(GameObject _obj)
		{
			DestroyComponents(_obj.GetComponents<Component>());
			_obj.transform.parent = gameObject.transform;
		}

		private void DestroyComponents(Component[] _objComponents)
		{
			foreach (var comp in _objComponents)
			{
				if (!(comp is Transform) && !(comp is MeshFilter) && !(comp is MeshRenderer))
				{
					Destroy(comp);
				}
			}
		}

	#endregion

	#region Private and Protected Members

		private float m_collider_size;

	#endregion
}
