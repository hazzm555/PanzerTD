using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersPlacer : MonoBehaviour
{
    public bool collided = false;
    public int collitionNumber = 0;
    public bool Placed = false;

    /*public bool Collided {
        get { return collided; }
        set { collided = value; }
    }*/

    // Start is called before the first frame update
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!Placed && collision.tag != "Projectiles")
        {
            

            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            if (transform.GetChild(0).childCount != 0)
            {
                transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            }
            transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;

            collided = true;
            collitionNumber++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Projectiles")
        {
            
            collitionNumber--;
            if (!Placed && collitionNumber == 0)
            {

                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white; if (transform.GetChild(0).childCount != 0)
                {
                    transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
                collided = false;
            }
        }
    }
}

    


