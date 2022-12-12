using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameMontage : MonoBehaviour
{
    int piezas;
    [SerializeField] int totalpiezas;
    public UnityEvent endminigame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AñadirPieza()
    {
        piezas++;
        if(piezas == totalpiezas)
        {
            EndMinigame();
        }
    }

    void EndMinigame()
    {
        Debug.Log("Fin");
        endminigame.Invoke();
        this.enabled = false;
    }
}
