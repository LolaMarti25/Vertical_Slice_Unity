using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;
    List<Collider> list = new List<Collider>();
    float counter;
    //float piezas = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rb.isKinematic = true;
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > 1)
        {
            if (list.Count == 0)
            {
                rb.isKinematic = false;
                collider.isTrigger = false;
            }
        }

        //if (piezas == 10)
        //{
        //    EndMinigame();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        list.Add(collider);
        //if (other.tag == "Contador")
        //{
        //    piezas = piezas + 1;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        list.Remove(collider);
    }
    //private void EndMinigame()
    //{

    //}
}
