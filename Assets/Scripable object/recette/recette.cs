using UnityEngine;

[CreateAssetMenu(fileName = "recette", menuName = "Scriptable Objects/recette")]
public class recette : ScriptableObject
{
    public ingrediant ingrediant1 = null;
    public ingrediant ingrediant2 = null;
    public ingrediant ingrediant3 = null;
    public type recetteMana1 = null;
    public type recetteMana2 = null;
    public type recetteMana3 = null;
    public int manaAmount1 = 0;
    public int manaAmount2 = 0;
    public int manaAmount3 = 0;
}
