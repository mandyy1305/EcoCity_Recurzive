using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;

    [SerializeField] private int buildingCost;

    private void OnEnable()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SpawnBuilding);
    }

    private void OnDisable()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(SpawnBuilding);
    }

    private void Start()
    {
        buildingCost = buildingPrefab.GetComponent<Building>().GetBuildingCost();
    }

    private void SpawnBuilding()
    {
        if (ResourceManager.instance.CanAfford(buildingCost))
        {
            print("Can afford building");
            //ResourceManager.instance.RemoveCurrency(buildingCost);
            Instantiate(buildingPrefab);
        }
        else
        {
            print("Can't afford building");
        }
    }


}
