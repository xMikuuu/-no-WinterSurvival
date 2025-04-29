using System.Collections;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    private bool generateMoney;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("AddResource");
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("AddResource");
            Debug.Log("exit");
        }
    }

    IEnumerator AddResource()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("+1 resource");
        }
    }

}
