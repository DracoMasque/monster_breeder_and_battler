using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ControlManaBar : MonoBehaviour
{
    [FormerlySerializedAs("type_mana")] [SerializeField] private TypeMana typeMana;
    [SerializeField] private playerStat player;
    private TextMeshProUGUI _text;
    [SerializeField] private Image image;
    public float typeManaAmount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        typeManaAmount = typeMana switch
        {
            TypeMana.AirMana => player.air_mana,
            TypeMana.EauMana => player.eau_mana,
            TypeMana.FeuMana => player.feu_mana,
            TypeMana.TerreMana => player.terre_mana,
            TypeMana.TempsMana => player.temps_mana,
            TypeMana.VideMana => player.vide_mana,
            TypeMana.EspaceMana => player.espace_mana,
            TypeMana.PlaceHolderMana => player.placeHolder_mana
        };
        _text.text = typeManaAmount.ToString();
        image.fillAmount = typeManaAmount/player.max_mana;
        
    }
}

public enum TypeMana
{
    AirMana,
    EauMana,
    FeuMana,
    TerreMana,
    TempsMana,
    VideMana,
    EspaceMana,
    PlaceHolderMana,
    None
}
