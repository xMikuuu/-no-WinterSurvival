using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float money;

    // Events
    public UnityEvent moneyUIUpdate;


    private void Start()
    {
        moneyUIUpdate = new UnityEvent();
        moneyUIUpdate.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        Debug.Log("updated UI");
    }
}
