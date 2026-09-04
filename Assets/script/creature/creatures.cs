using System.Collections.Generic;
using UnityEngine;

public class creatures : MonoBehaviour
{
    private type element;
    private float productionAmount;
    private float productionTime;
    private float currentProductionTime;

    public float health;
    private float currentMaxHealth;
    private float maxHealth;
    private float speed;
    private float maxSpeed;
    private float strength;
    private float maxStrength;
    private float defence;
    private float maxDefence;
    private float magic;
    private float maxMagic;
    private float mutationChance;

    private int age;
    private float maxAge;

    private bool isKO;
    private bool isDead;
    
    private List<gene> geneALL;
    private List<gene> geneExtra;
    private gene formeTete;
    private gene yeux;
    private gene oreilles;
    private gene nez;
    private gene bouche;
    private gene formeCorp;
    private gene jambeArreire;
    private gene jambeAvant;
    private gene patteArreire;
    private gene patteAvant;
    private gene queue;
    private gene squellette;
    private gene muscle;
    private gene taille;
    private gene pelagePeau;
    
    private playerStat player;
    
    private void Awake()
    {
        player = GameObject.Find("player").GetComponent<playerStat>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentProductionTime += Time.deltaTime;
    }

    public void GenerateMana(float multiplier)
    {
        if (currentProductionTime >= productionTime)
        {
            player.addMana(element.typeID, productionAmount * multiplier);
            currentProductionTime = 0;
        }
    }
}
