using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SellingPoint : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;
    private float sellingValue;
    [SerializeField] private int sellingDelay;

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

    IEnumerator SellResources()
    {
        yield return new WaitForSeconds(sellingDelay);
        foreach (var i in gameManager.resources.Keys)
        {
            for (int j = 0; j < gameManager.resourceList.ListOfScriptableObjects.Count; j++)
            {
                if(i == gameManager.resourceList.ListOfScriptableObjects[j].resourceName)
                {
                    sellingValue += gameManager.resources[i] * gameManager.resourceList.ListOfScriptableObjects[j].resourceValue;
                }
            }
        }
        gameManager.OnMoneyChange.Invoke(sellingValue);
        StopCoroutine("SellResources");
    }
}
