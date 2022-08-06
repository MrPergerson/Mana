using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage;
    public float knockbackForce;
    public Transform origin;

    public void InitializeHitbox(float damage, float knockbackForce, Transform origin)
    {
        this.damage = damage;
        this.knockbackForce = knockbackForce;
        this.origin = origin;

        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;

        transform.tag = "Hitbox";
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // could I reference actor instead?? look at layers

        if (collision.transform.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            var enemy = collision.gameObject.GetComponent<Enemy>();
            var knockback = transform.position - origin.position; // not the best, but will work for now. What is a good way to determine the direction of knockback?
            knockback.Normalize();
            enemy.Damage(damage, knockback * knockbackForce);
        }
        else if(collision.transform.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.Damage(damage);
        }
    }


}
