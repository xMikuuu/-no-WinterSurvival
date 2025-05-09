using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SellingPoint : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;
    private float sellingValue;
    [SerializeField] private float sellingDelay;

    private void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("SellResources");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("SellResources");
        }
    }

    IEnumerator SellResources()
    {
        List<string> keys = gameManager.resources.Keys.ToList();
        foreach (var i in keys)
        {
            for (int j = 0; j < gameManager.resourceList.ListOfScriptableObjects.Count; j++)
            {
                if(i == gameManager.resourceList.ListOfScriptableObjects[j].resourceName)
                {
                    float resourceAmmount = gameManager.resources[i];
                    for(float k = 0; k < resourceAmmount; k++)
                    {
                        sellingValue = gameManager.resourceList.ListOfScriptableObjects[j].resourceValue;
                        gameManager.OnMoneyChange.Invoke(sellingValue);
                        gameManager.OnResourceChange.Invoke(-1, i);
                        yield return new WaitForSeconds(sellingDelay);
                    }
                }
            }
        }
    }
}
