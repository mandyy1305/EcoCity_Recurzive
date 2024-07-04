using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager Instance;

    [SerializeField] private List<GameObject> serviceBuildings;
    [SerializeField] private List<GameObject> shopBuildings;
    [SerializeField] private List<GameObject> essentialBuildings;
    [SerializeField] private List<GameObject> foodBuildings;
    [SerializeField] private List<GameObject> factoryBuildings;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject GetRandomBuilding(BuildingType buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.Service:
                return serviceBuildings[Random.Range(0, serviceBuildings.Count)];
            case BuildingType.Shop:
                return shopBuildings[Random.Range(0, shopBuildings.Count)];
            case BuildingType.Essential:
                return essentialBuildings[Random.Range(0, essentialBuildings.Count)];
            case BuildingType.Food:
                return foodBuildings[Random.Range(0, foodBuildings.Count)];
            case BuildingType.Factory:
                return factoryBuildings[Random.Range(0, factoryBuildings.Count)];
            default:
                return null;
        }
    }

}

public enum BuildingType
{
    Service,
    Shop,
    Essential,
    Food,
    Factory
}
