using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript  : MonoBehaviour
{

    #region Public Members
    public Camera m_camera;
    public Transform m_cameraTargetTransform;
    public SphereCollider m_sphereCollider;
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
        m_perviousAngle = m_camera.transform.rotation.y;
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
        m_targetPosition += new Vector3(m_cameraXAjust, 0, m_cameraZAjust);
        transform.position = Vector3.Lerp(transform.position, m_targetPosition, Time.deltaTime * m_smooth);
        transform.LookAt(m_cameraTargetTransform);
    }
    private void RotateAroundTarget()
    {
        

        /*
        m_timer += Time.deltaTime;
        if(m_timer>0.5f)
        {
            Debug.Log(m_perviousAngle);
            Debug.Log(m_camera.transform.rotation.y);
            if (m_perviousAngle > m_camera.transform.rotation.y )
            {
                //m_cameraXAjust = -5;
                //m_cameraZAjust = 0;
            }
            else
            {
                if (m_perviousAngle  < m_camera.transform.rotation.y)
                {

                }
                else
                {

                }
            }
            m_timer = 0f;
            m_perviousAngle = m_camera.transform.rotation.y;
        }
        */
    }
    private void IncreaseDistanceWithScale()
    {
        // a tester et ajuster plus tard
        m_distanceUP = 5f + m_cameraTargetTransform.localScale.x + (m_sphereCollider.radius *25);
        m_distanceAway = 5f + m_cameraTargetTransform.localScale.x + (m_sphereCollider.radius *25);

    }

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Member
    private float m_timer=0f;
    private float m_timerAfterChange = 0f;

    private float m_cameraXAjust = 0f;
    private float m_cameraZAjust = 0f;

    private Transform m_previousTransform;
    private float m_perviousAngle;
    private Vector3 m_targetPosition;


    private float m_neededDistanceToGround = 5;

    private float m_neededDistanceToTarget = 5;
    #endregion

}
