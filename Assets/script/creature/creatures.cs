using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
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
    
    private List<Gene> geneALL;
    private List<Gene> geneExtra;
    [SerializeField] private Gene formeTete;
    [SerializeField] private Gene yeux;
    [SerializeField] private Gene oreilles;
    [SerializeField] private Gene nez;
    [SerializeField] private Gene bouche;
    [SerializeField] private Gene formeCorp;
    [SerializeField] private Gene jambeArreire;
    [SerializeField] private Gene jambeAvant;
    [SerializeField] private Gene patteArreire;
    [SerializeField] private Gene patteAvant;
    [SerializeField] private Gene queue;
    [SerializeField] private Gene squellette;
    [SerializeField] private Gene muscle;
    [SerializeField] private Gene taille;
    [SerializeField] private Gene pelagePeau;
    
    private PlayerStat player;
    
    private void Awake()
    {
        player = GameObject.Find("player").GetComponent<PlayerStat>();
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
