using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject
{
    public Sprite resourceIcon;
    public string resourceName;
    public float resourceValue;
    public float resourceTimeToObtain;
    public List<float> resourceAmmountObtained;
    public List<float> ammountOfResourceInVein;
}
