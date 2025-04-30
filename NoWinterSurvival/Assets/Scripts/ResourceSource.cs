using System.Collections;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    [SerializeField] private float ammountOfResource;
    [SerializeField] private float gatheringDelay;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("AddResource");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("AddResource");
        }
    }

    IEnumerator AddResource()
    {
        while (true)
        {
            yield return new WaitForSeconds(gatheringDelay);
            gameManager.OnResourceChange.Invoke(ammountOfResource);
        }
    }

}
