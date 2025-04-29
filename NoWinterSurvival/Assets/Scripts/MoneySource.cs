using System.Collections;
using UnityEngine;

public class MoneySource : MonoBehaviour
{
    private bool generateMoney;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("AddMoney");
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("AddMoney");
            Debug.Log("exit");
        }
    }

    IEnumerator AddMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("-1 res, +1gold");
            //to do moneyUIUpdate.Invoke();
        }
    }

}
