using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sandbox;

[RequireComponent(typeof(LevelBounds))]
public class PortalZone : MonoBehaviour
{
    [SerializeField] GameObject Portal;

    LevelBounds levelBounds;

    private void Awake()
    {
        levelBounds = GetComponent<LevelBounds>();
    }


    void Start()
    {

        RandomMagic random = new RandomMagic();

        var randomPosition = random.GetRandomPointInSquare(Vector2.zero, LevelBounds.AdjustedBounds.width, LevelBounds.AdjustedBounds.height);

        Instantiate(Portal, randomPosition, Quaternion.identity);
    }


    void Update()
    {
        //RandomMagic random = new RandomMagic();
        //var randomPosition = random.GetRandomPointInSquare(Vector2.zero, LevelBounds.Bounds.width, LevelBounds.Bounds.height);
        //print(randomPosition);

        var rate = 0f;
        var newSizeX = Mathf.Max(5, LevelBounds.AbsoluteBounds.size.x - (rate * Time.deltaTime));
        var newSizeY = Mathf.Max(5, LevelBounds.AbsoluteBounds.size.y - (rate * Time.deltaTime));
        levelBounds.SetBoundsSize(new Vector2(newSizeX, newSizeY));
        //levelBounds.SetBoundsSize(new Vector2(10, 10));

    }
}
