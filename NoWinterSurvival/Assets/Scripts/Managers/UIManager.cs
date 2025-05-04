using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputSettings;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text moneyText;
    [SerializeField] public TMP_Text coalText;
    [SerializeField] public TMP_Text ironText;
    [SerializeField] public TMP_Text goldText;
    public static UIManager Instance;
    private GameManager gameManager;
    public UnityEvent<float> OnMoneyChange = new UnityEvent<float>();
    public UnityEvent OnResourceChange = new UnityEvent();

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
        gameManager = GameManager.Instance;
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

    private void ResourceTextUpdate()
    {
        coalText.text = gameManager.resources["Coal"].ToString();
        ironText.text = gameManager.resources["Iron"].ToString();
        goldText.text = gameManager.resources["Gold"].ToString();
    }

}
