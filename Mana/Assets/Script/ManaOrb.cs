using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManaOrb : Ability
{

    [SerializeField] Sprite manaOrbSprite;
    SpriteRenderer spriteRenderer;
    List<Hitbox> orbs;


    [SerializeField, Range(0, 1000)] float orbitSpeed = 500;
    [SerializeField, Range(.5f, 2f)] float DistanceFromPlayer = 1;
    [SerializeField, Range(1,3)] int count = 1;



    private void Awake()
    {
        orbs = new List<Hitbox>();

        for(int i = 0; i < count; i++)
        {
            AddOrb();
        }

        ManaCost = .5f;
        
    }

    void Update()
    {
        if (isActive)
        {
            foreach (var orb in orbs)
            {
                orb.transform.RotateAround(transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            }

        }
    }    

    private void AddOrb()
    {
        var orb = new GameObject().AddComponent<Hitbox>();
        orb.InitializeHitbox(20, 4, this.transform);

        orb.transform.parent = this.transform;
        orb.gameObject.SetActive(false);

        spriteRenderer = orb.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = manaOrbSprite;
        spriteRenderer.sortingLayerName = "Instances";

        orbs.Add(orb);
    }
    
    public override void Cast()
    {
        float angleOffset = 360 / count;
        angleOffset = angleOffset * Mathf.Deg2Rad;

        float angle = 0;

        foreach(var orb in orbs)
        {
            var x = Mathf.Sin(angle);
            var y = Mathf.Cos(angle);
            var vectorOffset = new Vector2(x, y);
            vectorOffset.Normalize();


            orb.transform.localPosition = vectorOffset * DistanceFromPlayer;
            orb.gameObject.SetActive(true);
            isActive = true;

            angle += angleOffset;
        }
    }

    public override void Stop()
    {
        foreach (var orb in orbs)
        {
            orb.gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnDrawGizmos()
    {

        if(isActive)
        {
            foreach(var orb in orbs)
            {

                var knockback = orb.transform.position - orb.origin.position;
                knockback.Normalize();

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(orb.transform.position, orb.transform.position + knockback * .5f);
            }
        }
    }
}
