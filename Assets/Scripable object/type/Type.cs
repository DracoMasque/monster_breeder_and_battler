using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "type", menuName = "Scriptable Objects/type")]
public class type : ScriptableObject
{
    public List<type> weaknesses = new List<type>();
    public List<type> resist = new List<type>();
    public List<type> imune = new List<type>();
}
