using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject currentlyEnabledUI;
    [SerializeField] private InventoryButton currentlyEnabledUIInventoryButton;
    [SerializeField] private bool isAnyUIEnabled;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject CurrentlyEnabledUI()
    {
        return currentlyEnabledUI;
    }

    public void CurrentlyEnabledUI(GameObject ui, InventoryButton inventoryButton)
    {
        if (currentlyEnabledUI)
        { 
            currentlyEnabledUI.SetActive(false);
            currentlyEnabledUIInventoryButton.IsUIEnabled(false);
        }

        currentlyEnabledUI = ui;
        currentlyEnabledUIInventoryButton = inventoryButton;
    }

    public bool IsAnyUIEnabled()
    {
        return isAnyUIEnabled;
    }

    public void IsAnyUIEnabled(bool value)
    {
        isAnyUIEnabled = value;
    }

}
