using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class zoomCam : MonoBehaviour
{
    private CinemachineCamera camera;
    private float zoomTarget;
    private InputAction scrollAction;
    
    [SerializeField] private float multiplier = 2f, minZoom = 1f, maxZoom = 10f, smoothTime = 0.1f;
    private float velocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<CinemachineCamera>();
        scrollAction = InputSystem.actions["Zoom"];
        zoomTarget = camera.Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float zoomValue = scrollAction.ReadValue<Vector2>().y;
        zoomTarget -= zoomValue * multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);
        camera.Lens.OrthographicSize = Mathf.SmoothDamp(camera.Lens.OrthographicSize, zoomTarget, ref velocity, smoothTime);
    }
}
