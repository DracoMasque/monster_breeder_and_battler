using UnityEngine;

public class playerStat : MonoBehaviour
{
    [SerializeField] private float air_mana = 0;
    [SerializeField] private float eau_mana = 0;
    [SerializeField] private float feu_mana = 0;
    [SerializeField] private float terre_mana = 0;
    [SerializeField] private float temps_mana = 0;
    [SerializeField] private float vide_mana = 0;
    [SerializeField] private float espace_mana = 0;
    [SerializeField] private float placeHolder_mana = 0;
    
    [SerializeField] private int max_mana = 100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (air_mana > max_mana)
        {
            air_mana = max_mana;
        }
        else if (eau_mana > max_mana)
        {
            eau_mana = max_mana;
        }
        else if (feu_mana > max_mana)
        {
            feu_mana = max_mana;
        }
        else if (terre_mana > max_mana)
        {
            terre_mana = max_mana;
        }
        else if (temps_mana > max_mana)
        {
            temps_mana = max_mana;
        }
        else if (vide_mana > max_mana)
        {
            vide_mana = max_mana;
        }
        else if (espace_mana > max_mana)
        {
            espace_mana = max_mana;
        }
        else if (placeHolder_mana > max_mana)
        {
            placeHolder_mana = max_mana;
        }
    }

    public float getMana(TypeMana type)
    {
        switch (type)
        {
            case TypeMana.AirMana:
                return air_mana;
            case TypeMana.EauMana:
                return eau_mana;
            case  TypeMana.FeuMana:
                return feu_mana;
            case TypeMana.TerreMana:
                return terre_mana;
            case TypeMana.TempsMana:
                return temps_mana;
            case TypeMana.VideMana:
                return vide_mana;
            case TypeMana.PlaceHolderMana:
                return  placeHolder_mana;
        }
        return 0;
    }

    public bool addMana(TypeMana type, float value)
    {
        switch (type)
        {
            case TypeMana.AirMana:
                air_mana += value;
                return true;
            case TypeMana.EauMana:
                eau_mana += value;
                return true;
            case  TypeMana.FeuMana:
                feu_mana += value;
                return true;
            case TypeMana.TerreMana:
                terre_mana += value;
                return true;
            case TypeMana.TempsMana:
                temps_mana += value;
                return true;
            case TypeMana.VideMana:
                vide_mana += value;
                return true;
            case TypeMana.PlaceHolderMana:
                placeHolder_mana += value;
                return true;
        }

        return false;
    }

    public bool subMana(TypeMana type, float value)
    {
        switch (type)
        {
            case TypeMana.AirMana:
                air_mana -= value;
                return true;
            case TypeMana.EauMana:
                eau_mana -= value;
                return true;
            case  TypeMana.FeuMana:
                feu_mana -= value;
                return true;
            case TypeMana.TerreMana:
                terre_mana -= value;
                return true;
            case TypeMana.TempsMana:
                temps_mana -= value;
                return true;
            case TypeMana.VideMana:
                vide_mana -= value;
                return true;
            case TypeMana.PlaceHolderMana:
                placeHolder_mana -= value;
                return true;
        }

        return false;
    }

    public int getManaMax()
    {
        return max_mana;
    }
    
    public bool addManaMax(int value)
    {
        max_mana += value;
        return true;
    }

    public bool subManaMax(int value)
    {
        max_mana -= value;
        return true;
    }
}
