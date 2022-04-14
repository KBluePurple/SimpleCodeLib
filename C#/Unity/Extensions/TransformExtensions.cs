using System;

namespace KBluePurple.UsefulExtensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Transform이 2D에서 target을 바라보게 만든다.
        /// (Z 축을 회전축으로 사용하여 회전한다.)
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target">바라볼 좌표</param>
        public static void LookAt2D(this Transform transform, Vector2 target)
        {
            if (transform == null)
            {
                throw new ArgumentNullException(nameof(transform));
            }

            var position = transform.position;
            var direction = (target - (Vector2)position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = angleAxis;
        }
    }
}
