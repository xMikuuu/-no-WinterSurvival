using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public resourceNames resourceName;
    public upgradeTypes upgradeType;
    public float upgradeCost; // in int
    public float upgradeValue;


    public enum resourceNames
    {
        Coal,
        Iron,
        Gold
    }
    public enum upgradeTypes
    {
        Value,
        Speed,
        Vein,
        Obtain
    }

}
