using UnityEngine;
using System.Collections;

public class AlienBehaviour : MonoBehaviour {

    public float health = 200f;
    public float projectileSpeed;
    public float firingRate;

    public float shotsPerSec = 0.5f;

    public GameObject projectile;


    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {

        float probability = Time.deltaTime * shotsPerSec;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider);
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        GameObject laserBeam = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity) as GameObject;
        laserBeam.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
    }
}
