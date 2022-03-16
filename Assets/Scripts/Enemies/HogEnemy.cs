using System.Collections;
using UnityEngine;
namespace Enemies
{
    public class HogEnemy : AbstractEnemy
    {
        public HogEnemy()
        {
            hp = 25;
            damage = 2;
            moveSpeed = 20f;
            fireRate = 1f;
            isLeft = true;
            name = "Hog";
        }

        public HogEnemy(bool l)
        {
            hp = 10;
            damage = 1;
            moveSpeed = 20f;
            fireRate = 1f;
            isLeft = l;
            name = "Hog";
        }

        public HogEnemy(int h, int d, float m, float f, bool l)
        {
            hp = h;
            damage = d;
            moveSpeed = m;
            fireRate = f;
            isLeft = l;
            name = "Hog";
        }
    }
}
