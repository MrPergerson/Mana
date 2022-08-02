using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    [SerializeField] Vector2 size = Vector2.one * 5;
    [SerializeField] float padding;
    [SerializeField] bool boundToCamera;

    [SerializeField] SpriteMask mask;

    private static Rect _adjustedBounds;
    private static Rect _absoluteBounds;

    public static Rect AdjustedBounds
    {
        get { return _adjustedBounds; }
        private set {  _adjustedBounds = value;}
    }

    public static Rect AbsoluteBounds
    {
        get { return _absoluteBounds; }
        private set { _absoluteBounds = value; }
    }

    public void SetBoundsSize(Vector2 size)
    {
        this.size = size;
        UpdateBounds();

    }

    private void Awake()
    {
        UpdateBounds();
    }

    private void Update()
    {
        //UpdateBounds();
        //print(Bounds);

        if (mask)
        {
            //mask.bounds.size = Bounds.size; 

            //mask.ResetBounds();
            //var maskBounds = new Bounds(transform.position, size);
            //print(maskBounds.size);
            //mask.bounds = maskBounds;
            mask.transform.localScale = new Vector2(size.x / 2, size.y / 2);

        }

    }

    void UpdateBounds()
    {
        padding = Mathf.Clamp(padding, 0, Mathf.Min(size.x / 2, size.y / 2));
        Vector2 offset = new Vector2(padding * 2, padding * 2);


        if (boundToCamera)
        {
            var MainCamera = Camera.main;
            float cameraHeight = MainCamera.orthographicSize * 2;
            float cameraWidth = cameraHeight * MainCamera.aspect;
            //Vector2 cameraSize = new Vector2(cameraWidth, cameraHeight);
            //Vector2 cameraCenterPosition = MainCamera.transform.position;
            //Vector2 cameraBottomLeftPosition = cameraCenterPosition - (cameraSize / 2);
            //_bounds = new Rect(cameraBottomLeftPosition, cameraSize);

            size = new Vector2(cameraWidth, cameraHeight);
        }

        _absoluteBounds.size = size;
        _absoluteBounds.center = (Vector2)transform.position;
        _adjustedBounds.size = size - offset;
        _adjustedBounds.center = (Vector2) transform.position;
    }

    private void OnDrawGizmos()
    {
        /*
        if (boundToCamera)
        {
            var MainCamera = Camera.main;
            float cameraHeight = MainCamera.orthographicSize * 2;
            float cameraWidth = cameraHeight * MainCamera.aspect;

            size = new Vector2(cameraWidth, cameraHeight);
        }

        if (mask)
        {
            //var maskBounds = new Bounds(transform.position, Bounds.size);
            //mask.localBounds = maskBounds;
            mask.transform.localScale = new Vector2(size.x / 2, size.y / 2);
        }

        */
        var adjustedPadding = Mathf.Clamp(padding, 0, Mathf.Min(size.x / 2, size.y / 2));
        var paddingOffset = new Vector2(adjustedPadding*2, adjustedPadding*2);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Vector2.zero, size);
        Gizmos.DrawWireCube(Vector2.zero, size - paddingOffset);
    }
}