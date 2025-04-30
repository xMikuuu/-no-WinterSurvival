using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float money;
    private float resource;
    private float moneyUpdateValue;
    private float resourceUpdateValue;
    
    public static GameManager Instance;
    // Events
    public UnityEvent<float> OnMoneyChange = new UnityEvent<float>();
    public UnityEvent<float> OnResourceChange = new UnityEvent<float>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void OnEnable()
    {
        OnMoneyChange.AddListener(UpdateMoney);
        OnResourceChange.AddListener(UpdateResource);
    }
    private void OnDestroy()
    {
        OnMoneyChange.RemoveListener(UpdateMoney);
        OnResourceChange.RemoveListener(UpdateResource);
    }

    private void UpdateMoney(float moneyUpdateValue)
    {
        money += moneyUpdateValue;
        UIManager.Instance.OnMoneyChange.Invoke(money);
    }
    private void UpdateResource(float resourceUpdateValue)
    {
        resource += resourceUpdateValue;
        UIManager.Instance.OnResourceChange.Invoke(resource);
    }
}
