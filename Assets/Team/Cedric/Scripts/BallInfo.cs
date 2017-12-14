using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInfo : MonoBehaviour
{
	#region Public Members

	#endregion

	#region Public void

		public float GetSizeObject(Vector3 _vec3)
		{
			// Return the volume
			return _vec3.x * _vec3.y * _vec3.z;
		}

	#endregion

	#region System

	#endregion

	#region Tools Debug And Utility

	#endregion

	#region Private and Protected Members

	#endregion
}
