using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    [Space(10)]
    [Header("Building Properties")]
    public float revenueOnDemolish;
    public float taxGenerated;
    //public float increaseHappinessBy;
    public float waitForSeconds;

    [Space(10)]
    [Header("Gizmos")]
    public Color gizmoColor = Color.red;

    private Coroutine taxCoroutine;

    public override void Start()
    {
        base.Start();
        taxCoroutine = StartCoroutine(GenerateTax());
    }

    public override void Update()
    {
        base.Update();
    }

    IEnumerator GenerateTax()
    {
        yield return new WaitForSeconds(waitForSeconds);
        taxGenerated++;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        DrawCircle(transform.position, scanRadius, 100);
    }
    void DrawCircle(Vector3 position, float radius, int segments)
    {
        float angle = 2 * Mathf.PI / segments;
        Vector3 prevPoint = position + new Vector3(radius, 0, 0);

        for (int i = 1; i <= segments; i++)
        {
            float x = Mathf.Cos(angle * i) * radius;
            float z = Mathf.Sin(angle * i) * radius;
            Vector3 newPoint = position + new Vector3(x, 0, z);
            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }
    }
}
