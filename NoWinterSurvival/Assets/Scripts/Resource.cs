using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject
{
    public Image resourceIcon;
    public string resourceName;
    public float resourceValue;
    public float resourceTimeToObtain;
    //public int resourceTimeToSell;
    public List<int> resourceAmmountObtained;
    public List<int> ammountOfResourceInVein;
}
