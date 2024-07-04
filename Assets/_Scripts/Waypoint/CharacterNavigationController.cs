using UnityEngine;

public class CharacterNavigationController : MonoBehaviour
{
    [SerializeField] private float m_StopDistance;
    public bool hasReachedDestination;

    [SerializeField] private Vector3 m_Destination;

    [SerializeField] private float m_Speed;

    // Update is called once per frame
    void Update()
    {
        if (transform.position != m_Destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Destination, m_Speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(m_Destination - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

            if (Vector3.Distance(transform.position, m_Destination) < m_StopDistance)
            {
                hasReachedDestination = true;
            }
        }
        else
        {
            hasReachedDestination = true;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        m_Destination = destination;
        hasReachedDestination = false;
    }
}
