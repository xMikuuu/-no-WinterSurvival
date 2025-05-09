using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float money;
    private float resource;
    private float moneyUpdateValue;
    private float resourceUpdateValue;
    public Dictionary<string, float> resources;
    public static GameManager Instance;
    [SerializeField] public ResourceList resourceList;
    // Events
    public UnityEvent<float> OnMoneyChange = new UnityEvent<float>();
    public UnityEvent<float, string> OnResourceChange = new UnityEvent<float, string>();

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
        resources = new Dictionary<string, float>();
        for (int i = 0; i<resourceList.ListOfScriptableObjects.Count; i++)
        {
            resources.Add(resourceList.ListOfScriptableObjects[i].resourceName,0);
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
    private void UpdateResource(float resourceUpdateValue,string resourceName)
    {
        resources[resourceName] += resourceUpdateValue;
        UIManager.Instance.OnResourceChange.Invoke();
    }


    private void ClearDictionary()
    {
        List<string> dictKeys = new List<string>();
        foreach (var i in resources.Keys)
        {
            dictKeys.Add(i);
        }
        foreach (var key in dictKeys)
        {
            resources[key] = 0;
        }
        dictKeys.Clear();
        UIManager.Instance.OnResourceChange.Invoke();
    }
}
