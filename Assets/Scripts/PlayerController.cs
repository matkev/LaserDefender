using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float speed = 12f;
    public float padding = 1f;
    public float projectileSpeed;
    public float firingRate;

    public float xmin = -6.5f;
    public float xmax = 6.5f;

    public float goingLeft = 1f;
    public float goingRight = -1f;
    float straight = 0;

    public GameObject projectile;

    public AudioClip fireSound;

    public ParticleSystem leftThruster;
    public ParticleSystem rightThruster;

    public GameObject explosion;



    public float health = 100000f;
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));


        //print("player" + leftMost.x);
        //print("player" + rightMost.x);

        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;



        

    }
    void Fire()
    {
        GameObject laserBeam = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 0.675f, transform.position.z), Quaternion.identity) as GameObject;
        laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Die()
    {

        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        levelManager.LoadLevel("Lose");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);


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
                Die();            }
        }
    }


    // Update is called once per frame
    void Update () {
        var foll = leftThruster.forceOverLifetime;
        foll.enabled = true;

        var folr = rightThruster.forceOverLifetime;
        folr.enabled = true;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;


            
            foll.x = goingLeft;
            folr.x = goingLeft;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            
            foll.x = goingRight;
            folr.x = goingRight;
        }
        else
        {
            foll.x = straight;
            folr.x = straight;

        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }


        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);


    }
}
