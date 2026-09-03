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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = player.getMana(typeMana).ToString();
        image.fillAmount = player.getMana(typeMana)/player.getManaMax();
        
    }
}
