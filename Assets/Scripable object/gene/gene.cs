using UnityEngine;

[CreateAssetMenu(fileName = "gene", menuName = "Scriptable Objects/gene")]
public class gene : ScriptableObject
{
    [Header("visible by player")]
    public string geneName;
    public string geneDescription;
    public GameObject geneObject;
    public TypeGene geneType;
    public TypeGene geneType2 = TypeGene.None;
    public Stats geneStat1;
    public Operateur operateur1;
    public float geneStatValue1;
    public Stats geneStat2;
    public Operateur operateur2;
    public float geneStatValue2;
    public Stats geneStat3;
    public Operateur operateur3;
    public float geneStatValue3;
    
    [Header("aparition")]
    public float pickchance;
    public float dominantPercentage;
    public bool isDominant;
}
