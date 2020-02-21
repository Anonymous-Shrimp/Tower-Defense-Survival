using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float Speed = 5.0f;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;

    public float jumpSpeed = 10;

    [Space]

    public float health = 100;
    public Image healthBar;
    public Text healthText;

    [Space]

    public float IQ = 0;
    public float IQLEVEL = 1;
    public Image IQBar;
    public Text IQText;
    public Text IQTextLevel;
    public float IQIncrease = 0.1f;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input for axis
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculate the forward vector
        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

        if (move.magnitude > 1f) move.Normalize();

        

        // Calculate the rotation for the player
        move = transform.InverseTransformDirection(move);

        // Get Euler angles
        float turnAmount = Mathf.Atan2(move.x, move.z);

        transform.Rotate(0, turnAmount *  RotationSpeed * Time.deltaTime, 0);

        if (_characterController.isGrounded)
        {
            //_animator.SetBool("run", move.magnitude> 0);

            _moveDir = transform.forward * move.magnitude;

            _moveDir *= Speed;
            if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
        }

        _moveDir.y -= Gravity * Time.deltaTime;

        _characterController.Move(_moveDir * Time.deltaTime);

        //UI Controls
        healthBar.fillAmount = health / 100;
        IQBar.fillAmount = IQ / 100;
        healthText.text = Mathf.Round(health).ToString();
        IQText.text = Mathf.Round(IQ).ToString() + "%";
        IQTextLevel.text = IQLEVEL.ToString();
        if (IQ >= 100)
        {
            IQ = 0;
            IQLEVEL += 1;
        }
        IQ += IQIncrease / Time.deltaTime;
    }

}
