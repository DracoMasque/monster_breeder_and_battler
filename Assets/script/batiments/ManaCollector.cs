using System.Collections.Generic;
using UnityEngine;

public class ManaCollector : Batiment
{
    private Collider2D collectionZone;
    private List<Creatures> creatureInRange = new List<Creatures>();
    [SerializeField] private float multiplier = 0.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectionZone = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Creatures creature in creatureInRange)
        {
            creature.GenerateMana(multiplier);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Creature")
        {
            creatureInRange.Add(collision.gameObject.GetComponent<Creatures>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Creature")
        {
            creatureInRange.Remove(collision.gameObject.gameObject.GetComponent<Creatures>());
        }
    }
}
