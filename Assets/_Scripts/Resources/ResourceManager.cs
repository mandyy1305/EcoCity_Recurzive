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
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    public void RemoveCurrency(int amount)
    {
        currency -= amount;
    }

    public bool CanAfford(int amount)
    {
        return currency >= amount;
    }




}
