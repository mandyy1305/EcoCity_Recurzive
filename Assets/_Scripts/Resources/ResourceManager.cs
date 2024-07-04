using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public int startingCurrency;

    [SerializeField]
    private int currency;

    public int Currency
    {
        get { return currency; }
        private set { currency = value; }
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currency = startingCurrency;
        UIManager.Instance.UpdateMoney(currency);
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        UIManager.Instance.UpdateMoney(currency);
    }

    public void RemoveCurrency(int amount)
    {
        currency -= amount;
        UIManager.Instance.UpdateMoney(currency);
    }

    public bool CanAfford(int amount)
    {
        return currency >= amount;
    }




}
