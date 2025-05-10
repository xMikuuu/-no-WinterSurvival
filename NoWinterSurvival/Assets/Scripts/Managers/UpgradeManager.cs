using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private float playerMovementSpeedModifier;

    private float coalValueModifier;
    private float coalSpeedModifier;
    private float coalObtainingModifier;
    private float coalVineModifier;

    private float ironValueModifier;
    private float ironSpeedModifier;
    private float ironObtainingModifier;
    private float ironVineModifier;

    private float goldValueModifier;
    private float goldSpeedModifier;
    private float goldObtainingModifier;
    private float goldVineModifier;

    public Dictionary<string, float> CoalModifiers;
    public Dictionary<string, float> IronModifiers;
    public Dictionary<string, float> GoldModifiers;

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

    }
    public void Upgrade(Upgrade upgrade)
    {
        Debug.Log(upgrade.name);
    } 
}
