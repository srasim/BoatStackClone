using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 tempPosition;
    public GameObject firstBoat;
    public List<GameObject> boats;

    void Start()
    {
        boats.Add(firstBoat);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 5);//TODO : Just for test
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
            for (int i = 0; i < collision.transform.localScale.y; i++)
            {
                LoseBoat();
            }
            Destroy(collision.gameObject);
        }
    }

    private void EarnBoat(Collider collision)
    {
        OthersUp();
        collision.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
        collision.isTrigger = false;
        boats.Add(collision.gameObject);
        collision.gameObject.transform.parent = this.transform;//make child
    }
    private void OthersUp()
    {
        tempPosition = this.transform.position;
        tempPosition.y += 1;//TODO : Not always 1 ...
        this.transform.position = tempPosition;
    }
    private void OthersDown()
    {
        tempPosition = this.transform.position;
        tempPosition.y -= 1;//TODO : Not always 1 ...
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
    }

}
