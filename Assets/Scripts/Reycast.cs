using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Reycast : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public float force;
    public GameObject polvo;

    public AudioSource rock;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, 100, mask))
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * force, ForceMode.Impulse);
                Instantiate(polvo, hit.point, Quaternion.identity);
                if (!rock.isPlaying)
                {
                    rock.Play();
                }
            }
        }
        else
        {
            rock.Stop();
        }
    }
}
