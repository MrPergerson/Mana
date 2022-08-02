using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxAreaGenerator2D : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] Vector2 size = Vector2.one;
    [SerializeField] float padding;
    [SerializeField] bool SnapToLevelBounds;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform poolContainer;

    private void Start()
    {

        if(SnapToLevelBounds)
        {
            size = LevelBounds.AdjustedBounds.size;
        }

        if(!poolContainer)
        {
            poolContainer = transform;
        }

        GeneratePoints();

        padding = Mathf.Clamp(padding, 0, Mathf.Min(size.x, size.y));
    }

    private void GeneratePoints()
    {
        for(int i = 0; i < points; i++)
        {

            //Random.InitState((int)System.DateTime.Now.Ticks);
            var randomPoint = new Vector2(Random.Range(padding, size.x-padding), Random.Range(padding, size.y-padding));
            var offset = new Vector2(size.x / 2, size.y / 2);
            var point = Instantiate(objectToSpawn, randomPoint-offset, Quaternion.identity, poolContainer);
        }
    }
   
    private void OnDrawGizmosSelected()
    {
        if (SnapToLevelBounds)
        {
            size = LevelBounds.AdjustedBounds.size;
        }

        Color sizeColor = new Color(1, 1, 0);
        Color paddingColor = new Color(0.62f, 0.62f, 0.00f);

        var adjustedPadding = Mathf.Clamp(padding, 0, Mathf.Min(size.x/2, size.y/2));
        var paddingOffset = new Vector2(adjustedPadding * 2, adjustedPadding * 2);

        Gizmos.color = sizeColor;
        Gizmos.DrawWireCube(transform.position, size);
        Gizmos.color = paddingColor;
        Gizmos.DrawWireCube(transform.position, size - paddingOffset);
    }
}
