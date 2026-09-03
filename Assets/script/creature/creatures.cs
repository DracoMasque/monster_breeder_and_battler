using System.Collections.Generic;
using UnityEngine;

public class creatures : MonoBehaviour
{
    private type element;
    private float productionAmount;
    private float productionTime;

    public float health;
    private float maxHealth;
    private float speed;
    private float maxSpeed;
    private float strength;
    private float maxStrength;
    private float defence;
    private float maxDefence;
    private float magic;
    private float maxMagic;

    private int age;
    private float maxAge;

    private bool isKO;
    private bool isDead;
    
    private List<gene>  geneALL;
    
    
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
        
    }

    public void GenerateMana(float multiplier)
    {
        player.addMana(element.typeID, productionAmount * multiplier);
    }
}
