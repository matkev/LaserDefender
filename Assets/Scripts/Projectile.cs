using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float damage = 100f;

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }


    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("hit something");
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
    */
}
