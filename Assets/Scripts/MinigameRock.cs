using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameRock : MonoBehaviour
{
    public List<Rigidbody> piezas;
    public UnityEvent endminigame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int piezasactivas = 0;
        for (int i = 0; i < piezas.Count; i++)
        {
            if (piezas[i].isKinematic == false)
            {
                piezasactivas++;
            }
        }
        if (piezasactivas == piezas.Count)
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
