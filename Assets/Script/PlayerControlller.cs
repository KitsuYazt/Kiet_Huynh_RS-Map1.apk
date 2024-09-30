using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public VariableJoystick joystick;
    public CameraController cameraController;
    public Canvas inputCanvas;
    public bool isJoystick;
    public CharacterController characterController;
    public WaveControll waveControll;
    public WinGame winGame;
    public DataHandler dataHandler;
    private float rotationSpeed = 10f;
    public Animator animator;
    public CatHolder catHolder;
    [HideInInspector] public Rigidbody rb;
    public CoolDown cd;
    Vector3 maxSp;
    PlayerMenuController playerMenuController;
    void Start()
    {
        cd = new CoolDown();
        cd.duration = 3;
        rb = GetComponent<Rigidbody>();
        EnableJoystickInput();
        dataHandler.Load();
        catHolder = characterController.GetComponent<CatHolder>();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);

    }

    public void Lose()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
            characterController.SimpleMove(movementDirection * dataHandler.moveSp);
            if (movementDirection.sqrMagnitude <= 0)
            {
                animator.SetBool("Run", false);
                animator.SetFloat("Movement Multiplier", 0);
                return;
            }
            animator.SetFloat("Movement Multiplier", 1);
            animator.SetBool("Run", true);
            var targetDirection = Vector3.RotateTowards(characterController.transform.forward
                , movementDirection,
                rotationSpeed * Time.deltaTime, 0f);

            characterController.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
        if (winGame.winGame)
        {
            waveControll.endGame = true;
            isJoystick = true;
        }
        if (cd.isFinished)
        {
            rb.velocity = maxSp;
            Debug.Log(rb.velocity);
        }
    }

    public void SpeedUp()
    {
        if (cameraController.line2 && !cd.isFinished)
        {
            rb.velocity = new Vector3(0, 0, rb.velocity.z + dataHandler.moveSp);
            maxSp = rb.velocity;
        }

    }


}
