using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [Header("Model")]
    public GameObject Character;
    public CapsuleCollider Collider;
    public float altura;
    public float radio;
    public float croughaltura;
    public float croughradio;

    [Header("Movimiento")]
    public float moveSpeed = 10;
    public float sprintSpeed;
    public float crouchSpeed;

    [Header("Ground Check")]
    bool grounded;
    public float groundCheck;

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching
    }

    [Header("Camera")]
    public Camera camara;
    public float sensitividad_vertical = 1000;
    public float sensitividad_horizontal = 1000;
    public float vertical_max = 80;
    public float vertical_min = -80;
    Vector3 rotacion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheck))
        {
            grounded = true;
            Debug.DrawRay(transform.position, -transform.up * groundCheck, Color.green);
        }
        else
        {
            grounded = false;
            Debug.DrawRay(transform.position, -transform.up * groundCheck, Color.red);
        }


    }
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * sensitividad_horizontal * Time.deltaTime;
        rotacion.y = rotacion.y + mouse_x;
        transform.eulerAngles = new Vector3(0, rotacion.y, 0);

        StateHandler();

        Collider.height = altura;
        Collider.radius = radio;

        float movimiento_horitzontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float movimiento_vertical = Input.GetAxis("Vertical") * Time.deltaTime;
        switch (state)
        {
            case MovementState.walking:
                movimiento_horitzontal *= moveSpeed;
                movimiento_vertical *= moveSpeed;
                break;
            case MovementState.sprinting:
                movimiento_horitzontal *= sprintSpeed;
                movimiento_vertical *= sprintSpeed;
                break;
            case MovementState.crouching:
                movimiento_horitzontal *= crouchSpeed;
                movimiento_vertical *= crouchSpeed;
                Collider.height = croughaltura;
                Collider.radius = croughradio;
                break;
            default:
                break;
        }
        transform.position = transform.position + (transform.forward * movimiento_vertical) + (transform.right * movimiento_horitzontal);

    }

    private void StateHandler()
    {
        state = MovementState.walking;
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
        }

        if (Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
        }
    }
    void LateUpdate()
    {
        float mouse_y = Input.GetAxis("Mouse Y") * sensitividad_vertical * Time.deltaTime;
        rotacion.x = Mathf.Clamp(rotacion.x + mouse_y, vertical_min, vertical_max);
        camara.transform.localEulerAngles = new Vector3(rotacion.x, 0, 0);

    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
