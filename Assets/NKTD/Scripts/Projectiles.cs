using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public GameObject MyTower;
    public GameObject Target;
    public float Damage = 0f;
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
            Vector2 direction = ((Vector2)Target.transform.position - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.up = direction;

        }
        else
        {
            Debug.Log("No Target");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.transform.GetComponent<Enemies>().Hp -= MyTower.GetComponent<Towers>().Damage;

            Destroy(gameObject);
        }
    }


}
