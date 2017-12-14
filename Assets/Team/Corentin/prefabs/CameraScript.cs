using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript  : MonoBehaviour
{

    #region Public Members
    public Camera m_camera;
    public Transform m_cameraTargetTransform;
    public Rigidbody m_cameraTargetBody;

    public float m_smooth = 1f;
    public float m_distanceUP=5f;
    public float m_distanceAway=5f;

    #endregion


    #region Public Void
    #endregion


    #region System
    private void Awake()
    {
        m_previousTransform = m_camera.transform;
    }
    void FixedUpdate()
    {
        FollowAndLookAtTarget();
        RotateAroundTarget();
        IncreaseDistanceWithScale();

    }
    #endregion

    #region Private Void
    private void FollowAndLookAtTarget()
    {
        m_targetPosition = m_cameraTargetTransform.position + (Vector3.up * m_distanceUP) - (Vector3.forward * m_distanceAway);
        transform.position = Vector3.Lerp(transform.position, m_targetPosition, Time.deltaTime * m_smooth);
        transform.LookAt(m_cameraTargetTransform);
    }
    private void RotateAroundTarget()
    {
        m_timer += Time.deltaTime;
        if(m_timer>2f)
        {
            Debug.Log(m_previousTransform.eulerAngles.y.ToString());
            Debug.Log(m_camera.transform.eulerAngles.y.ToString());
            if (m_previousTransform.eulerAngles.y > m_camera.transform.eulerAngles.y)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 10);
            }
            else if (m_previousTransform.eulerAngles.y < m_camera.transform.eulerAngles.y)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 10);
            }
            m_timer = 0f;
            m_previousTransform = m_camera.transform;
        }
        
    }
    private void IncreaseDistanceWithScale()
    {
        // a tester et ajuster plus tard
        m_distanceUP = 5f + m_cameraTargetTransform.localScale.x;
        m_distanceAway = 5f + m_cameraTargetTransform.localScale.x;

    }

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Member
    private float m_timer=0f;
    private Transform m_previousTransform;
    private Vector3 m_targetPosition;

    private float m_neededDistanceToGround = 5;

    private float m_neededDistanceToTarget = 5;
    #endregion

}
