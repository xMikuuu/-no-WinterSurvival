using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceList", menuName = "Scriptable Objects/ResourceList")]
public class ResourceList : ScriptableObject
{
    public List<Resource> ListOfScriptableObjects;
}
