using UnityEngine;

public class Enemies : MonoBehaviour
{
    
    public int KillGold = 100;
    public float BaseHp;
    public float Hp = 100f;
    public int Damage = 1;
    public bool Killed = false;

    public SpriteRenderer spB, spC;
    private Color color;
    public ManagerScene Manager;
    // Start is called before the first frame update
    void Start()
    {
        BaseHp = Hp;
        color = Color.red;
        color.g = 1;
        color.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Projectiles")
        {


            color.g = (255 * (Hp / BaseHp)) / 255;
            color.b = (255 * (Hp / BaseHp)) / 255;
            spB.color = color;
            spC.color = color;
            if (Hp <= 0 && !Killed)
            {
                Killed = true;
                ManagerScene.EnemiesList.Remove(gameObject);
                transform.GetComponent<TankMovement>().Manager.IncreaseGold(KillGold);
                Manager.EnemiesKilledThisWave++;    
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "EndPoint")
        {

            Manager.ReduceLives(Damage);
            Manager.EnemiesKilledThisWave++;
            //if(Manager.EnemiesAlive == 0)
            Destroy(gameObject);
        }
    }

}
