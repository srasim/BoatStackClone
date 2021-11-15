using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject firstBoat;
    public List<GameObject> boats;
    void Start()
    {
        boats.Add(firstBoat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
