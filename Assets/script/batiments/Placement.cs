using System;
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
    private Transform placementPosition;
    private InputAction mousePos;
    private InputAction button;
    
    public TypeMana costMana1;
    public TypeMana costMana2;
    public TypeMana costMana3;
    public int manaAmount1 = 0;
    public int manaAmount2 = 0;
    public int manaAmount3 = 0;
    
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
        placementPosition = GetComponent<Transform>();
        placementMat = GetComponent<Renderer>().material;
        mousePos = InputSystem.actions["mousePosBatiment"];
        button = InputSystem.actions["leftClickPlaceBat"];
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();
        
        if (bloking.Count != 0 || EnoughMana())
        {
            print(bloking.Count);
            print(EnoughMana());
            plassable = false;
            placementMat.SetColor("_Color", Color.red);
        }
        else
        {
            print("plassable");
            plassable = true;
            placementMat.SetColor("_Color", Color.green);
        }

        if (button.triggered)
        {
            Place();
        }
    }

    private bool EnoughMana()
    {
        bool mana1 = false;
        bool mana2 = false;
        bool mana3 = false;
        if (costMana1 != TypeMana.None)
        {
            if (player.getMana(costMana1) - manaAmount1 < 0)
            {
                mana1 = true;
            }
            else
            {
                mana1 = false;
            }
        }
        else
        {
            mana1 = false;
        }

        if (costMana2 != TypeMana.None)
        {
            if (player.getMana(costMana2) - manaAmount2 < 0)
            {
                mana2 = true;
            }
            else 
            {
                mana2 = false;
            }
        }
        else
        {
            mana2 = false;
        }

        if (costMana3 != TypeMana.None)
        {
            if (player.getMana(costMana3) - manaAmount3 < 0)
            {
                mana3 = true;
            }
            else
            {
                mana3 = false;
            }
        }
        else
        {
            mana3 = false;
        }

        if (mana1 || mana2 || mana3)
        {
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    public void Place()
    {
        if (plassable)
        {
            print("performed");
            Payment();
            Instantiate(batiment, placementPosition.position, placementPosition.rotation);
            Destroy(gameObject);
        }
    }

    private void Payment()
    {
        if (costMana1 != TypeMana.None)
        {
            player.subMana(costMana1,manaAmount1);
        }
        
        if (costMana2 != TypeMana.None)
        {
            player.subMana(costMana2,manaAmount2);
        }
        
        if (costMana3 != TypeMana.None)
        {
            player.subMana(costMana3,manaAmount3);
        }
    }

    private void FollowMousePosition()
    {
        placementPosition.position = GetWorldPosition();
    }
    
    private Vector2 GetWorldPosition()
    {
        return mainCam.ScreenToWorldPoint(mousePos.ReadValue<Vector2>());
    }
}
