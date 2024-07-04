using UnityEngine;

public class Road : MonoBehaviour, ICannotPlaceHere
{
    public Vector3 GetRandomPoint()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), 0, Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));

        return transform.position + randomPosition;
    }
}
