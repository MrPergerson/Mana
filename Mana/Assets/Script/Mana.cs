using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : Collectable
{
    [SerializeField] float value = 1;

    protected override void Collect(GameObject collector)
    {
        base.Collect(collector);

        if(collector.tag == "Player")
        {
            var player = collector.GetComponent<Player>();
            player.CollectMana(value);
        }
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(collision.gameObject);
        Destroy(this.gameObject, .2f);
    }
}
