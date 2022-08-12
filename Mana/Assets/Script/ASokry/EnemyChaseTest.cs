using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseTest : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") && player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (player != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);
        }
    }
}
