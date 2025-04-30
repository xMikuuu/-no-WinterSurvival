using System.Collections;
using UnityEngine;

public class MoneySource : MonoBehaviour
{
    [SerializeField] private float sellValue;
    [SerializeField] private float sellDelay;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("AddMoney");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("AddMoney");
        }
    }

    IEnumerator AddMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(sellDelay);
            //gameManager.money += sellValue;
            gameManager.OnMoneyChange.Invoke(sellValue);
        }
    }

}
