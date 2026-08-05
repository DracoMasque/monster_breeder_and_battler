using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class controlManaBar : MonoBehaviour
{
    [SerializeField] private type_mana type_mana;
    [SerializeField] private playerStat player;
    private TextMeshProUGUI text;
    [SerializeField] private Image image;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type_mana == type_mana.air_mana)
        {
            float ratio = player.air_mana/player.max_mana;
            print(player.air_mana/player.max_mana);
            text.text = player.air_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.eau_mana)
        {
            float ratio = player.eau_mana/player.max_mana;
            text.text = player.eau_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.feu_mana)
        {
            float ratio = player.feu_mana/player.max_mana;
            text.text = player.feu_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.terre_mana)
        {
            float ratio = player.terre_mana/player.max_mana;
            text.text = player.terre_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.temps_mana)
        {
            float ratio = player.temps_mana/player.max_mana;
            text.text = player.temps_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.vide_mana)
        {
            float ratio = player.vide_mana/player.max_mana;
            text.text = player.vide_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.espace_mana)
        {
            float ratio = player.espace_mana/player.max_mana;
            text.text = player.espace_mana.ToString();
            image.fillAmount = ratio;
        }
        else if (type_mana == type_mana.placeHolder_mana)
        {
            float ratio = player.placeHolder_mana/player.max_mana;
            text.text = player.placeHolder_mana.ToString();
            image.fillAmount = ratio;
        }
        
    }
}

enum type_mana
{
    air_mana,
    eau_mana,
    feu_mana,
    terre_mana,
    temps_mana,
    vide_mana,
    espace_mana,
    placeHolder_mana
}
