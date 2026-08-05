using UnityEngine;

public class playerStat : MonoBehaviour
{
    public float air_mana = 0;
    public float eau_mana = 0;
    public float feu_mana = 0;
    public float terre_mana = 0;
    public float temps_mana = 0;
    public float vide_mana = 0;
    public float espace_mana = 0;
    public float placeHolder_mana = 0;
    
    public int max_mana = 100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (air_mana >= max_mana)
        {
            air_mana = max_mana;
        }
        else if (eau_mana >= max_mana)
        {
            eau_mana = max_mana;
        }
        else if (feu_mana >= max_mana){
            feu_mana = max_mana;}
        else if (terre_mana >= max_mana){
            terre_mana = max_mana;}
        else if (temps_mana >= max_mana){
            temps_mana = max_mana;}
        else if (vide_mana >= max_mana){
            vide_mana = max_mana;}
        else if (espace_mana >= max_mana)
        {
            espace_mana = max_mana;
        }
        else if (placeHolder_mana >= max_mana){
            placeHolder_mana = max_mana;}
    }
}
