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
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();
        
        if (bloking.Count != 0 || player.getMana(costMana1) - manaAmount1 <= 0 
                               || player.getMana(costMana2) - manaAmount2 <= 0 
                               || player.getMana(costMana3) - manaAmount3 <= 0)
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
        if (!ctx.performed)
        {
            return;
        }
        if (plassable)
        {
            Instantiate(batiment, placementPosition.position, placementPosition.rotation);
            Payment();
            gameObject.SetActive(false);
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
