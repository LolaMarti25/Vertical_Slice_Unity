using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Model")]
    public GameObject Character;

    [Header("Movimiento")]
    Rigidbody rb;
    public float velocidad = 10;

    [Header("Camera")]
    public Camera camara;
    public float sensitividad_vertical = 1000;
    public float sensitividad_horizontal = 1000;
    public float vertical_max = 80;
    public float vertical_min = -80;
    Vector3 rotacion;

    bool MouseMode = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (MouseMode == false)
        {
            float mouse_x = Input.GetAxis("Mouse X") * sensitividad_horizontal * Time.deltaTime;
            rotacion.y = rotacion.y + mouse_x;
            transform.eulerAngles = new Vector3(0, rotacion.y, 0);

            float movimiento_horitzontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
            float movimiento_vertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

            transform.position = transform.position + (transform.forward * movimiento_vertical) + (transform.right * movimiento_horitzontal);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            MouseMode = true;
        }
    }

    void LateUpdate()
    {
        if (MouseMode == false)
        {
            float mouse_y = Input.GetAxis("Mouse Y") * sensitividad_vertical * Time.deltaTime;
            rotacion.x = Mathf.Clamp(rotacion.x + mouse_y, vertical_min, vertical_max);
            camara.transform.localEulerAngles = new Vector3(rotacion.x, 0, 0);
        }
    }
}
