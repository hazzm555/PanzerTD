using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float speed = 1f;
    public GameObject[] MovePoints;
    public int MoveTo = 0;
    public ManagerScene Manager;
    public Rigidbody2D Rb;


    // Start is called before the first frame update
    void Start()
    {
        Manager.TankMovementPointsGetter(this);

    }

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, MovePoints[MoveTo].transform.position, speed * Time.fixedDeltaTime);
        if(transform.position == MovePoints[MoveTo].transform.position)
        {
            MoveTo++;
            Vector2 direction = ((Vector2)MovePoints[MoveTo].transform.position - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.up = direction;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, MovePoints[0].transform.position, speed * Time.deltaTime);
    }
}
