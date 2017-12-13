using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript  : MonoBehaviour
{

    #region Public Members
    public Camera m_camera;
    public GameObject m_cameraTarget;
    public float m_cameraDistanceToGround;
    public float m_cameraDistanceToTarget;

    #endregion


    #region Public Void
    public void ChangeCameraDistance()
    {
        
    }
    #endregion


    #region System

    void Start () 
    {
		
	}
    void Awake () 
    {
        m_cameraBody = m_camera.GetComponent<Rigidbody>();
        m_camera.transform.LookAt(m_cameraTarget.transform);
        m_neededDistanceToGround = m_cameraTarget.transform.localScale.y + m_cameraTarget.transform.localScale.y * 0.5f + 5;
    }
	
	void Update () 
    {
        m_camera.transform.LookAt(m_cameraTarget.transform);

        //body.AddForce(transform.up * 5f);
        //AddForce(transform.forward * thrust);
        //transform.forward

        RaycastHit hit;
        if (Physics.Raycast(m_camera.transform.position, Vector3.down, out hit))
        {

        }
        Debug.DrawLine(m_camera.transform.position, Vector3.down, Color.red);

        //m_cameraBody.AddForce(transform.up * differenceInHeight);


        /*
        float dist = Vector3.Distance(m_cameraTarget.transform.position, m_camera.transform.position);
        float differenceInDistanceToTarget = dist - m_neededDistanceToTarget;
        m_cameraBody.AddForce(transform.forward * differenceInDistanceToTarget);
        */
        if (hit.distance > m_neededDistanceToGround)
        {
            m_camera.transform.Translate(transform.forward * Time.deltaTime);
        }
        else
        {
            m_camera.transform.Translate(transform.up * Time.deltaTime);
        }
        
        //m_camera.transform.Translate(m_cameraTarget.transform.position.x + 10, m_cameraTarget.transform.position.y + 10, m_cameraTarget.transform.position.z + 10);
        //m_camera.transform.position= new Vector3(m_cameraTarget.transform.position.x+10, m_cameraTarget.transform.position.y+10, m_cameraTarget.transform.position.z+10);
    }

    #endregion

    #region Private Void

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members
    private float m_neededDistanceToGround = 5;
    private float m_neededDistanceToTarget = 5;
    private Rigidbody m_cameraBody;
    #endregion

}
