using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject currentlyEnabledUI;
    [SerializeField] private InventoryButton currentlyEnabledUIInventoryButton;
    [SerializeField] private bool isAnyUIEnabled;

    [SerializeField] private int currentHappiness;

    [SerializeField] private Image happinessRadialImage;
    [SerializeField] private TextMeshProUGUI happinessText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateHappiness(100);
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

    public void UpdateHappiness(int value)
    {
        currentHappiness = value;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, 100);

        happinessRadialImage.fillAmount = currentHappiness / 100f;
        happinessText.text = $"{currentHappiness}%";
    }
    
    public int GetHappiness()
    {
        return currentHappiness;
    }

}
