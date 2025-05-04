using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSource : MonoBehaviour
{
    private int ammountOfResource;
    private float gatheringDelay;
    private ResourceList resourceList;
    [SerializeField] private TMP_Text resourceText;
    [SerializeField] private SpriteRenderer resourceImage;
    private Resource resource;
    private int resourceAmmountInVein;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        resourceList = gameManager.resourceList;
        resource = resourceList.ListOfScriptableObjects[UnityEngine.Random.Range(0, resourceList.ListOfScriptableObjects.Count)];
        gatheringDelay = resource.resourceTimeToObtain;

        resourceAmmountInVein = UnityEngine.Random.Range(resource.ammountOfResourceInVein[0], resource.ammountOfResourceInVein[1]);
        resourceText.text = resource.resourceName + "\n(" + resourceAmmountInVein + ")";
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
            ammountOfResource = UnityEngine.Random.Range(resource.resourceAmmountObtained[0], resource.resourceAmmountObtained[1]);
            if(resourceAmmountInVein - ammountOfResource < 0)
            {
                ammountOfResource = resourceAmmountInVein;
                Destroy(gameObject);
            }
            resourceAmmountInVein -= ammountOfResource;
            resourceText.text = resource.resourceName + "\n(" + resourceAmmountInVein + ")";
            gameManager.OnResourceChange.Invoke(ammountOfResource,resource.resourceName);
        }
    }

}
