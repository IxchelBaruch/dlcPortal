
using UnityEngine;
using System.Collections;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject player = null;
    public GameObject defaultPos = null;
    GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;
    public GameObject aimingPart;

    private void Start()
    {
        m_target = defaultPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - aimingPart.transform.position);
            }

            if (aimingPart.transform.rotation != m_lookAtRotation)
            {
                aimingPart.transform.rotation = Quaternion.RotateTowards(aimingPart.transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            m_target = player;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            m_target = defaultPos;
    }
}
