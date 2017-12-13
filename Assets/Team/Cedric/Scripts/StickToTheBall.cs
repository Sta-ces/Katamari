using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTheBall : Ball
{
	#region Public Members

		public Transform m_objectPlayer;

	#endregion

	#region Public void

	#endregion

	#region System

		void Awake()
		{
			m_objectCollider_size = GetSizeObject(m_collider.bounds.size);
		}

		void Update()
		{
		}

		void OnCollisionEnter(Collision col)
		{
			m_objectCollider_size = GetSizeObject(m_collider.bounds.size);
			Collider collider = col.gameObject.GetComponent<Collider>();
			float col_size = GetSizeObject(collider.bounds.size);
			if(col_size < m_objectCollider_size)
			{
				float addScale = col_size * 0.5f;
				transform.localScale += new Vector3(addScale,addScale,addScale);
				Debug.Log(m_objectCollider_size);
				StickObject(col.gameObject, col_size);
			}
		}

	#endregion

	#region Tools Debug And Utility

		private float GetSizeObject(Vector3 _vec3)
		{
			return _vec3.x * _vec3.y * _vec3.z;
		}

		private void StickObject(GameObject _obj, float _colSize)
		{
			_obj.transform.parent = m_objectPlayer;
			DestroyComponents(_obj.GetComponents<Component>());
		}

		private void DestroyComponents(Component[] _objComponents)
		{
			foreach (var comp in _objComponents)
			{
				if (!(comp is Transform) && !(comp is MeshFilter) && !(comp is MeshRenderer) && !(comp is Collider))
				{
					Destroy(comp);
				}
			}
		}

	#endregion

	#region Private and Protected Members

		private float m_objectCollider_size;

	#endregion
}
