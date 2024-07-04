using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject UIToEnable;
    public InventoryButtonType inventoryButtonType;

    private bool isUIEnabled = false;

    private void Start()
    {
        if (inventoryButtonType == InventoryButtonType.OpenUI)
        {
            UIToEnable.SetActive(false);
            return;
        }

        
    }

    private void Update()
    {
        if (inventoryButtonType == InventoryButtonType.OpenUI && isUIEnabled && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
            DisableUI(); 
    }

    private void OnEnable()
    {
        if (inventoryButtonType == InventoryButtonType.OpenUI)
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(EnableUI);
        else if (inventoryButtonType == InventoryButtonType.SpawnRandomBuilding)
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SpawnBuilding);
    }

    private void OnDisable()
    {
        if (inventoryButtonType == InventoryButtonType.OpenUI)
            GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(EnableUI);
        else if (inventoryButtonType == InventoryButtonType.SpawnRandomBuilding)
            GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(SpawnBuilding);
    }

    private void EnableUI()
    {
        if (isUIEnabled) return;
        UIToEnable.SetActive(true);
        UIManager.Instance.CurrentlyEnabledUI(UIToEnable, this);
        isUIEnabled = true;
    }

    private void DisableUI()
    {
        if (!isUIEnabled) return;
        UIToEnable.SetActive(false);
        UIManager.Instance.CurrentlyEnabledUI(null, null);
        isUIEnabled = false;
    }

    public bool IsUIEnabled()
    {
        return isUIEnabled;
    }

    public void IsUIEnabled(bool value)
    {
        isUIEnabled = value;
    }

    private void SpawnBuilding()
    {
        
    }
}

public enum InventoryButtonType
{
    SpawnRandomBuilding,
    OpenUI,
}
