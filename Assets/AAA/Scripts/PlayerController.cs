using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 tempPosition;
    public GameObject firstBoat;
    public List<GameObject> boats;
    float boatsYSize;

    public delegate void PlayerInfoForStates();
    public event PlayerInfoForStates OnPlayerDead;
    public event PlayerInfoForStates OnTriggerDiamond;

    void Start()
    {
        boats.Add(firstBoat);
        boatsYSize = firstBoat.GetComponent<MeshFilter>().mesh.bounds.size.y * firstBoat.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Boat" && !boats.Contains(collision.gameObject))
        {
            EarnBoat(collision);
        }
        else if (collision.gameObject.tag == "Spike")
        {
            Destroy(collision.gameObject);
            LoseBoat();
        }
        else if (collision.gameObject.tag == "Wall")
        {
            float howManyBoats = collision.GetComponent<MeshFilter>().mesh.bounds.size.y * collision.transform.localScale.y / boatsYSize;
            for (int i = 0; i < howManyBoats; i++)
            {
                LoseBoat();
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Diamond")
        {
            Destroy(collision.gameObject);
            if(OnTriggerDiamond != null)
            {
                OnTriggerDiamond();
            }
        }
    }

    private void EarnBoat(Collider collision)
    {
        OthersUp();
        collision.transform.position = new Vector3(this.transform.position.x, boatsYSize/2, this.transform.position.z);
        collision.isTrigger = false;
        boats.Add(collision.gameObject);
        collision.gameObject.transform.parent = this.transform;//make child
    }
    private void OthersUp()
    {
        tempPosition = this.transform.position;
        tempPosition.y += boatsYSize;
        this.transform.position = tempPosition;
    }
    private void OthersDown()
    {
        tempPosition = this.transform.position;
        tempPosition.y -= boatsYSize;
        this.transform.position = tempPosition;

    }
    private void LoseBoat()
    {
        if (boats.Count != 0)
        {
            OthersDown();
            Destroy(boats[boats.Count - 1]);
            boats.RemoveAt(boats.Count - 1);
        }
        if (boats.Count < 1)
        {
            if (OnPlayerDead != null)
            {
                OnPlayerDead();
            }
        }
    }
    public void PlayerMove()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 5);
    }

}
