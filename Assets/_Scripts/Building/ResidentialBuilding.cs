using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    [Space(10)]
    [Header("Building Properties")]
    public int residentCapacity;

    [Space(10)]
    [Header("Gizmos")]
    public Color gizmoColor = Color.yellow;


    public override void Start()
    {
        base.Start();
        Debug.Log(residentCapacity);
    }

    public override void Update()
    {
        base.Update();
    }

    private void Building_OnBuildingPlaced(Building building)
    {
        Debug.Log("Building Placed and event called --> " + building.scanRadius);

        //Distance checking
        var pos1 = building.transform.position; pos1.y = 0;
        var pos2 = transform.position; pos2.y = 0;

        float distance = Vector3.Distance(pos1, pos2);
        Debug.Log("Distance: " + distance + " Resident Capacity: " + residentCapacity + " Increase By: " + building.increaseHappinessBy);

        if (distance < building.scanRadius)
        {
            //Update Happiness Index
            if (building is not IndustrialBuilding)
            {
                GameManager.UpdateAverageHappinessIndexOnBuildingPlaced(residentCapacity, building.increaseHappinessBy);
            }

            //Check if a commercial store has been setup
            //To know at the time of establishment how many people are near the store to generate revenue accordingly
            if(building is CommercialBuilding commercialBuilding)
            {
                commercialBuilding.residentsAroundRadius += residentCapacity;
            }
            else if(building is IndustrialBuilding industrialBuilding)
            {
                industrialBuilding.residentsAroundRadius += residentCapacity;
            }
        }


        //Update Total Residents
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
