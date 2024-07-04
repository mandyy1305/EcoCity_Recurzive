using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalResidents;
    public static float averageHappinessIndex;

    public static int totalApartments_50cap;
    public static int totalApartments_30cap;
    public static int totalApartments_5cap;

    public static int totalApartments;
    public static int totalApartmentCapacity;

    private void Start()
    {
        totalResidents = 1000;
        averageHappinessIndex = 82f;
    }


    public static void UpdateApartments_50cap()
    {
        totalApartments_50cap++;
        totalApartments++;
        totalApartmentCapacity += 50;
    }

    public static void UpdateApartments_30cap()
    {
        totalApartments_30cap++;
        totalApartments++;
        totalApartmentCapacity += 30;
    }

    public static void UpdateApartments_5cap()
    {
        totalApartments_5cap++;
        totalApartments++;
        totalApartmentCapacity += 5;
    }

    public static void UpdateAverageHappinessIndexOnBuildings(int residentCapacity, float increaseHappinessBy)
    {
        //If all residents have houses to live in, no change in happinessIndex

        Debug.Log("Current Happiness: " + averageHappinessIndex );

        int currentResidents = totalResidents - residentCapacity;
        float currentHappinessTotal = currentResidents * averageHappinessIndex;
        float newHappinessTotal = residentCapacity * (averageHappinessIndex + increaseHappinessBy);

        float updatedHappinessTotal = currentHappinessTotal + newHappinessTotal;
        averageHappinessIndex = updatedHappinessTotal / totalResidents;

        Debug.Log("Updated Happiness: " + averageHappinessIndex);
    }
}
