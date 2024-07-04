using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ICannotPlaceHere
{
    [SerializeField] protected int buildingCost;
    [SerializeField] protected bool isPlaced;
    [SerializeField] protected bool canBePlaced;

    private Quaternion rotation;

    [SerializeField] protected LayerMask grassMask;

    protected List<Color> defaultColors;
    protected Color errorColor = Color.red;

    protected int revenueGenerated;
    [Range(25f, 80f)]
    public float scanRadius;
    public float increaseHappinessBy;
    public float revenueOnDemolish;

    public static event Action<Building> OnBuildingPlaced;

    
    

    public virtual void Start()
    {
        defaultColors = new List<Color>();

        foreach (Material mat in GetComponent<MeshRenderer>().materials)
        {
            defaultColors.Add(mat.color);
        }

        canBePlaced = true;
        rotation = transform.rotation;

        scanRadius = 100f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ICannotPlaceHere iCannotPlaceHere))
        {
            DisplayErrorColor();
            canBePlaced = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ICannotPlaceHere iCannotPlaceHere))
        {
            DisplayErrorColor();
            canBePlaced = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ICannotPlaceHere iCannotPlaceHere))
        {
            DisplayDefaultColor();
            canBePlaced = true;
        }
    }

    public int GetBuildingCost()
    {
        return buildingCost;
    }

    public virtual void Update()
    {
        if (isPlaced)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(Vector3.up, 90);
            rotation = transform.rotation;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, grassMask))
        {
            int xPosition = Mathf.RoundToInt(hit.point.x / 4) * 4;
            int zPosition = Mathf.RoundToInt(hit.point.z / 4) * 4;
            transform.position = new Vector3(xPosition, 0, zPosition);

            transform.rotation = rotation;

            if (Input.GetMouseButtonDown(0) && canBePlaced)
            {
                isPlaced = true;
                OnBuildingPlaced?.Invoke(this);
                ResourceManager.instance.RemoveCurrency(buildingCost);
                UIManager.Instance.CurrentlyEnabledUI(null, null);
                UIManager.Instance.IsAnyUIEnabled(false);

                if(this is ResidentialBuilding residentialBuilding)
                {
                    GameManager.UpdateHomedResidentsNumber(residentialBuilding.residentCapacity);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Destroy(gameObject);

    }


    public void DemolishBuilding()
    {
        ResourceManager.instance.AddCurrency((int)revenueOnDemolish);
        Destroy(gameObject);
    }

    private void DisplayErrorColor()
    {
        foreach (Material mat in GetComponent<MeshRenderer>().materials)
        {
            mat.color = errorColor;
        }
    }

    private void DisplayDefaultColor()
    {
        for (int i = 0; i < defaultColors.Count; i++)
        {
            GetComponent<MeshRenderer>().materials[i].color = defaultColors[i];
        }
    }

}
