using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalResidents;
    public static float averageHappinessIndex;

    public static int totalHomedResidents;
    public static int totalHomelessResidents;

    //Coverages
    public static float healthCoverage;
    public static float literacyCoverage;
    public static float retailCoverage;


    //Inspector Values
    public int waitForSeconds;
    private Coroutine coroutine;

    private void Start()
    {
        totalResidents = 500;
        UIManager.Instance.UpdatePopulation(totalResidents);
        totalHomedResidents = 0;
        totalHomelessResidents = totalResidents - totalHomedResidents;

        averageHappinessIndex = 62f;
        UIManager.Instance.UpdateHappiness(averageHappinessIndex);

        coroutine = StartCoroutine(IncrementPopulation());
    }


    public static void UpdateHomedResidentsNumber(int value)
    {
        if(totalHomedResidents < totalResidents)
        {
            totalHomedResidents += value;
            totalHomelessResidents = totalResidents - totalHomedResidents;

            Debug.Log("Homed: " + totalHomedResidents + " Homeless: " + totalHomelessResidents);
        }
    }


    public static void UpdateAverageHappinessIndexOnBuildingPlaced(int residentCapacity, float increaseHappinessBy)
    {
        //If all residents have houses to live in, no change in happinessIndex

        Debug.Log("Current Happiness: " + averageHappinessIndex );

        int currentResidents = totalResidents - residentCapacity;
        float currentHappinessTotal = currentResidents * averageHappinessIndex;
        float newHappinessTotal = residentCapacity * (averageHappinessIndex + increaseHappinessBy);

        float updatedHappinessTotal = currentHappinessTotal + newHappinessTotal;
        averageHappinessIndex = updatedHappinessTotal / totalResidents;
        averageHappinessIndex = Mathf.Clamp(averageHappinessIndex, 0, 100);
        Debug.Log("Updated Happiness: " + averageHappinessIndex);

        //Change UI Happiness
        UIManager.Instance.UpdateHappiness(averageHappinessIndex);

    }

    IEnumerator IncrementPopulation()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitForSeconds);
            totalResidents++;
            UIManager.Instance.UpdatePopulation(totalResidents);

            //Decrement Happiness index
            averageHappinessIndex -= totalHomelessResidents * 0.0002f;
            UIManager.Instance.UpdateHappiness(averageHappinessIndex);
        }
    }
}
