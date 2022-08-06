using AllIn1SpriteShader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(AllIn1Shader))]
public abstract class Actor : MonoBehaviour
{
    public Rigidbody2D rb;
    protected SpriteRenderer sprite;

    protected Material material;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        material = GetComponent<Renderer>().material;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual IEnumerator Flash(float duration)
    {
        var startTime = Time.time;
        var time = 0f;
        material.SetFloat("_FlickerFreq", 1f);

        yield return new WaitUntil(() =>
        {
            time += Time.deltaTime;
            float percent = (time) / duration;

            material.SetFloat("_FlickerPercent", percent);

            return Time.time - startTime > duration;
        });

        material.SetFloat("_FlickerPercent", 0);

    }

}
