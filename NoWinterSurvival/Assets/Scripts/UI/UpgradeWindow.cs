using UnityEngine;

public class UpgradeWindow : MonoBehaviour
{
    [SerializeField] private GameObject UpgradesCanvas;
    private bool isUpgradesCavasOn;

    public void OnButtonClick()
    {
        Debug.Log("button clicked");
        UpgradesCanvas.SetActive(!isUpgradesCavasOn);
        isUpgradesCavasOn = !isUpgradesCavasOn;


    }
}
