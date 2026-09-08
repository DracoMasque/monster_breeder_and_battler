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
    [SerializeField] private gene formeTete;
    [SerializeField] private gene yeux;
    [SerializeField] private gene oreilles;
    [SerializeField] private gene nez;
    [SerializeField] private gene bouche;
    [SerializeField] private gene formeCorp;
    [SerializeField] private gene jambeArreire;
    [SerializeField] private gene jambeAvant;
    [SerializeField] private gene patteArreire;
    [SerializeField] private gene patteAvant;
    [SerializeField] private gene queue;
    [SerializeField] private gene squellette;
    [SerializeField] private gene muscle;
    [SerializeField] private gene taille;
    [SerializeField] private gene pelagePeau;
    
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
