using UnityEngine;

public class Towers : MonoBehaviour
{

    public float Radius = 5f;
    public GameObject ClosestEnemy;
    private Collider2D MyCollider;
    public float DefaultDistance= 6f;
    public float DistanceToClosestEnemy = 6f;
    public GameObject [] Projectiles;
    public int ProjectileNumber;

    public float FireRate = 1f;
    public float FireReloadTime = 0f;

    public int Level = 1;
    public int Damage = 1;
    public int price = 100;

    public ManagerScene Manager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(name);
        if (gameObject.name.Contains("SmallGreenTower"))
        {
            
            Level = SavedData.SmallGreenCannonLVL - 1;
            Damage = (int)SavedData.SmallGreenCannonStats[0, Level];
            FireRate = SavedData.SmallGreenCannonStats[1, Level];

        }
        else if (gameObject.name.Contains("SmallRedTower"))
        {

            Level = SavedData.SmallRedCannonLVL - 1;
            Damage = (int)SavedData.SmallRedCannonStats[0, Level];
            FireRate = SavedData.SmallRedCannonStats[1, Level];

        }
        else if (gameObject.name.Contains("SmallRocketLancher"))
        {

            Level = SavedData.SmallRocketLancherLVL - 1;
            Damage = (int)SavedData.SmallRocketLancherStats[0, Level];
            FireRate = SavedData.SmallRocketLancherStats[1, Level];

        }
        else if (gameObject.name.Contains("HeavyGreenTower"))
        {

            Level = SavedData.HeavyGreenCannonLVL - 1;
            Damage = (int)SavedData.HeavyGreenCannonStats[0, Level];
            FireRate = SavedData.HeavyGreenCannonStats[1, Level];

        }
        else if (gameObject.name.Contains("HeavyRedTower"))
        {

            Level = SavedData.HeavyRedCannonLVL - 1;
            Damage = (int)SavedData.HeavyRedCannonStats[0, Level];
            FireRate = SavedData.HeavyRedCannonStats[1, Level];

        }
        else if (gameObject.name.Contains("HeavyRocketLancher"))
        {

            Level = SavedData.HeavyRocketLancherLVL - 1;
            Damage = (int)SavedData.HeavyRocketLancherStats[0, Level];
            FireRate = SavedData.HeavyRocketLancherStats[1, Level];

        }
    }

    // Update is called once per frame
    private float DistanceHolder;

    private void OnMouseDown()
    {
        Manager.SetSelectedTower(gameObject);
    }



    void Update()
    {
        if (FireReloadTime > 0)
        {
            FireReloadTime -= Time.deltaTime;
        }

        foreach (GameObject Enemy in ManagerScene.EnemiesList)
        {
            if (Enemy != null)
            {
                DistanceHolder = Vector2.Distance(transform.position, Enemy.transform.position);

                if (DistanceHolder < Radius && DistanceHolder < DistanceToClosestEnemy)
                {
                    
                    DistanceToClosestEnemy = DistanceHolder;
                    ClosestEnemy = Enemy;

                }
                else if( ClosestEnemy != null)
                {
                    DistanceToClosestEnemy = Vector2.Distance(transform.position, ClosestEnemy.transform.position);
                }
                
                if (ClosestEnemy != null && Vector2.Distance(transform.position, ClosestEnemy.transform.position) > Radius)
                {

                    
                    ClosestEnemy = null;
                    DistanceToClosestEnemy = DefaultDistance;

                }
                if (ClosestEnemy == null)
                {
                    DistanceToClosestEnemy = DefaultDistance;
                }
            }
            
        }

        if (ClosestEnemy != null)
        {
            
            Vector2 direction = ((Vector2)ClosestEnemy.transform.position - (Vector2)transform.GetChild(0).position).normalized;

            // set vector of transform directly
            transform.GetChild(0).up = direction;

            if (FireReloadTime <= 0)
            {
                Fire(ClosestEnemy);
            }
        }

    }

    public void Fire(GameObject Target)
    {
        FireReloadTime = FireRate;
        GameObject myProjectile = Instantiate(Projectiles[ProjectileNumber], transform.position, transform.rotation, transform);
        Projectiles projectile = myProjectile.GetComponent<Projectiles>();
        projectile.MyTower = gameObject;
        projectile.Target = Target;
        //projectile.Damage = 10 * Mathf.Pow(2, Level - 1);

    }
   
}
