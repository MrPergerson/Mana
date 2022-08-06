using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{

    public class RandomMagic
    {
        public float GetRandomAngle()
        {
            return 2 * Mathf.PI * UnityEngine.Random.Range(0f, 1f);
        }

        public Vector2 GetRandomDirection2D()
        {
            var angle = GetRandomAngle();
            //angle = (angle / Mathf.PI) * 180;
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);

            return new Vector2(x, y);
        }

        public Vector2 GetRandomPointInSquare(Vector2 center, float width, float height)
        {
            var minX = center.x - (width / 2);
            var maxX = center.x + (width / 2);
            var minY = center.y - (height / 2);
            var maxY = center.y + (height / 2);

            //Random.InitState((int)System.DateTime.Now.Ticks);
            return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}