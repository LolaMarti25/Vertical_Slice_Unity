using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera mainCamara;
    private float CameraZDistance;

    public GameObject target;
    public LayerMask mask;

    float movementSpeed;

    Vector3 PosicionOriginal;
    Quaternion RotacionOriginal;
    Vector3 PosicionFinal;
    Quaternion RotacionFinal;

    bool IsDraging;
    [SerializeField] MinigameMontage minigameMontage;

    private Vector3 mOffset;

    private float mzCoord;
    private void Start()
    {
        PosicionOriginal = transform.position;
        RotacionOriginal = transform.rotation;

        PosicionFinal = target.transform.position;
        RotacionFinal = target.transform.rotation;

        movementSpeed = 10;
    }
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hitted = Physics.Raycast(ray, out hit, 100, mask);

        if (IsDraging && hitted && hit.transform.gameObject == target)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, movementSpeed * Time.deltaTime);
        }
        else
        {
            //Si no toca la pieza target, pones la rotacion original y la posicion del mouse
            transform.position = Vector3.Lerp(transform.position, transform.position, movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, RotacionOriginal, movementSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0) && IsDraging)
        {
            if (hitted && hit.transform.gameObject == target)
            {
                transform.position = PosicionFinal;
                transform.rotation = RotacionFinal;
                minigameMontage.AñadirPieza();

                this.enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                target.SetActive(false);
            }
            else
            {
                transform.position = PosicionOriginal;
                transform.rotation = RotacionOriginal;
            }
        }
    }
    //    if (Input.GetMouseButtonUp(0) && IsDraging)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 100, mask))
    //        {
    //            if(hit.transform.gameObject == target)
    //            {
    //                transform.position = PosicionFinal;
    //                transform.rotation = RotacionFinal;
    //                minigameMontage.AñadirPieza();
    //                this.enabled = false;
    //            }
    //            else
    //            {
    //                transform.position = PosicionOriginal;
    //                transform.rotation = RotacionOriginal;
    //            }
    //        }
    //        else
    //        {
    //            transform.position = PosicionOriginal;
    //            transform.rotation = RotacionOriginal;
    //        }
    //    }
    //}
    void OnMouseDown()
    {
        IsDraging = false;
        mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mzCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        IsDraging = true;
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
