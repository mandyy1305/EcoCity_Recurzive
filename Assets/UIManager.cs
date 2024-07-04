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

    [SerializeField] private float currentHappiness;
    [SerializeField] private int currentPopulation;

    [SerializeField] private Image happinessRadialImage;
    [SerializeField] private TextMeshProUGUI happinessText;

    [SerializeField] private TextMeshProUGUI populationText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        
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

    public void UpdateHappiness(float value)
    {
        currentHappiness = value;
        currentHappiness = Mathf.Round(currentHappiness * 100.0f) * 0.01f;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, 100);

        happinessRadialImage.fillAmount = currentHappiness / 100f;
        happinessText.text = $"{Mathf.RoundToInt(currentHappiness)}%";
    }

    public void UpdatePopulation(int value)
    {
        currentPopulation = value;
        populationText.text = $"{currentPopulation}";
    }

    public void UpdateMoney(int value)
    {
        moneyText.text = $"{value}";
    }

    public float GetHappiness()
    {
        return currentHappiness;
    }

}
