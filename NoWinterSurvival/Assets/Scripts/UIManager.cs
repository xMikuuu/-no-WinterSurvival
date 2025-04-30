using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputSettings;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text moneyText;
    [SerializeField] public TMP_Text resourceText;

    public static UIManager Instance;

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
        OnMoneyChange.AddListener(MoneyTextUpdate);
        OnResourceChange.AddListener(ResourceTextUpdate);
    }
    private void OnDestroy()
    {
        OnMoneyChange.RemoveListener(MoneyTextUpdate);
        OnResourceChange.RemoveListener(ResourceTextUpdate);
    }

    private void MoneyTextUpdate(float value)
    {
        moneyText.text = value.ToString();
    }

    private void ResourceTextUpdate(float value)
    {
        resourceText.text = value.ToString();
    }

}
