using UnityEngine;

public class ButtonPlacement : MonoBehaviour
{
    [SerializeField] private GameObject batimentToPlace;

    public void createPlacement()
    {
        Instantiate(batimentToPlace, transform.position, transform.rotation);
    }
}
