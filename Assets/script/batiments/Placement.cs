using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Placement : MonoBehaviour
{
    [SerializeField] private Batiment batiment;
    [SerializeField] private bool plassable;
    private Camera mainCam;
    private Collider2D collider;
    [SerializeField] private List<GameObject> bloking = new List<GameObject>();
    public Material placementMat;
    private Transform position;
    private InputAction mousePos;
    
    public TypeMana costMana1;
    public TypeMana costMana2;
    public TypeMana costMana3;
    public int manaAmount1 = 0;
    public int manaAmount2 = 0;
    public int manaAmount3 = 0;

    public float playerMana1;
    public float playerMana2;
    public float playerMana3;
    
    [SerializeField] private playerStat player;

    private void Awake()
    {
        player = GameObject.Find("player").GetComponent<playerStat>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        collider = GetComponent<Collider2D>();
        position = GetComponent<Transform>();
        placementMat = GetComponent<Renderer>().material;
        mousePos = InputSystem.actions["mousePosBatiment"];
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();
        
        if (costMana1 != TypeMana.None)
        {
            playerMana1 = costMana1 switch
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
        }
        
        if (costMana2 != TypeMana.None)
        {
            playerMana2 = costMana1 switch
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
        }
        
        if (costMana3 != TypeMana.None)
        {
            playerMana3 = costMana1 switch
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
        }
        
        if (bloking.Count != 0 && playerMana1 - manaAmount1 <= 0 
                               && playerMana2 - manaAmount2 <= 0 
                               && playerMana3 - manaAmount3 <= 0)
        {
            plassable = false;
            placementMat.SetColor("Color", Color.red);
        }
        else
        {
            plassable = true;
            placementMat.SetColor("Color", Color.green);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.CompareTag("Batiment"))
        {
            bloking.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Batiment"))
        {
            bloking.Remove(collision.gameObject);
        }
    }

    public void Place(InputAction.CallbackContext ctx)
    {
        if (plassable)
        {
            Instantiate(batiment, position);
            Payment();
            gameObject.SetActive(false);
        }
    }

    private void Payment()
    {
        if (costMana1 != TypeMana.None)
        {
            switch (costMana1)
            {
                case TypeMana.AirMana:
                    player.air_mana -= manaAmount1;
                    break;
                case TypeMana.EauMana:
                    player.eau_mana -= manaAmount1;
                    break;
                case TypeMana.FeuMana:
                    player.feu_mana -= manaAmount1;
                    break;
                case TypeMana.TerreMana:
                    player.terre_mana -= manaAmount1;
                    break;
                case TypeMana.TempsMana:
                    player.temps_mana -= manaAmount1;
                    break;
                case TypeMana.VideMana:
                    player.vide_mana -= manaAmount1;
                    break;
                case TypeMana.EspaceMana:
                    player.espace_mana -= manaAmount1;
                    break;
                case TypeMana.PlaceHolderMana:
                    player.placeHolder_mana -= manaAmount1;
                    break;
            }
        }
        
        if (costMana2 != TypeMana.None)
        {
            switch (costMana2)
            {
                case TypeMana.AirMana:
                    player.air_mana -= manaAmount2;
                    break;
                case TypeMana.EauMana:
                    player.eau_mana -= manaAmount2;
                    break;
                case TypeMana.FeuMana:
                    player.feu_mana -= manaAmount2;
                    break;
                case TypeMana.TerreMana:
                    player.terre_mana -= manaAmount2;
                    break;
                case TypeMana.TempsMana:
                    player.temps_mana -= manaAmount2;
                    break;
                case TypeMana.VideMana:
                    player.vide_mana -= manaAmount2;
                    break;
                case TypeMana.EspaceMana:
                    player.espace_mana -= manaAmount2;
                    break;
                case TypeMana.PlaceHolderMana:
                    player.placeHolder_mana -= manaAmount2;
                    break;
            }
        }
        
        if (costMana3 != TypeMana.None)
        {
            switch (costMana3)
            {
                case TypeMana.AirMana:
                    player.air_mana -= manaAmount3;
                    break;
                case TypeMana.EauMana:
                    player.eau_mana -= manaAmount3;
                    break;
                case TypeMana.FeuMana:
                    player.feu_mana -= manaAmount3;
                    break;
                case TypeMana.TerreMana:
                    player.terre_mana -= manaAmount3;
                    break;
                case TypeMana.TempsMana:
                    player.temps_mana -= manaAmount3;
                    break;
                case TypeMana.VideMana:
                    player.vide_mana -= manaAmount3;
                    break;
                case TypeMana.EspaceMana:
                    player.espace_mana -= manaAmount3;
                    break;
                case TypeMana.PlaceHolderMana:
                    player.placeHolder_mana -= manaAmount3;
                    break;
            }
        }
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPosition();
    }
    
    private Vector2 GetWorldPosition()
    {
        return mainCam.ScreenToWorldPoint(mousePos.ReadValue<Vector2>());
    }
}
