using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    [Space(10)]
    [Header("Building Properties")]
    //public float taxGenerated;
    public float waitForSeconds;
    public int residentsAroundRadius;

    private Coroutine coroutine;
    
    public override void Start()
    {
        base.Start();
        coroutine = StartCoroutine(ReduceHappiness());
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    IEnumerator ReduceHappiness()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitForSeconds);

            if (isPlaced)
            {
                GameManager.UpdateAverageHappinessIndexOnBuildingPlaced(residentsAroundRadius, -increaseHappinessBy);
            }

        }
    }

    private void Building_OnBuildingPlaced(Building building)
    {
        if (building is ResidentialBuilding residentialBuilding)
        {
            //Distance checking
            var pos1 = building.transform.position; pos1.y = 0;
            var pos2 = transform.position; pos2.y = 0;

            float distance = Vector3.Distance(pos1, pos2);

            if (distance < building.scanRadius)
            {
                //Check if a commercial store has been setup
                //To know at the time of establishment how many people are near the store to generate revenue accordingly
                residentsAroundRadius += residentialBuilding.residentCapacity;
            }
        }


    }

    #region Enable Disable
    private void OnEnable()
    {
        Building.OnBuildingPlaced += Building_OnBuildingPlaced;
    }


    private void OnDisable()
    {
        Building.OnBuildingPlaced -= Building_OnBuildingPlaced;
    }

    #endregion

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
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
