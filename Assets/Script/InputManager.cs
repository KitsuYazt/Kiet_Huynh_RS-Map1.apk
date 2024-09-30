using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Touchcontroll touchControl;
    [SerializeField] private PlayerMenuController playerMenuController;
    [SerializeField] private PlayerControlller playerControlller;
    [SerializeField] private Rect touchArea = new Rect(0, Screen.height / 4, Screen.width, Screen.height / 2);

    private void Awake()
    {
        touchControl = new Touchcontroll();
    }

    private void OnEnable()
    {
        touchControl.Enable();
    }
    private void OnDisable()
    {
        touchControl.Disable();
    }

    private void Start()
    {
        touchControl.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControl.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {

    }

    private void EndTouch(InputAction.CallbackContext context)
    {

        Vector2 touchPosition = touchControl.Touch.TouchPosition.ReadValue<Vector2>();
        if (touchArea.Contains(touchPosition))
        {
            playerMenuController.Run(true);
            playerControlller.SpeedUp();
        }

    }
    private void Update()
    {
       
    }

    
}
