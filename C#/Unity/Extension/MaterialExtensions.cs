using System;

namespace KBluePurple.UsefulExtensions
{
    public static class MaterialExtensions
    {
        /// <summary>
        /// Material의 색상을 변경한다.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Material SetRGB(this Material material, int r, int g, int b)
        {
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material));
            }
            Color color = new Color(r / 255f, g / 255f, b / 255f);
            color.a = 1f;
            material.color = color;
            return material;
        }

        /// <summary>
        /// Material의 색상을 변경한다.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Material SetRGBA(this Material material, int r, int g, int b, float a)
        {
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material));
            }
            Color color = new Color(r / 255f, g / 255f, b / 255f);
            color.a = a;
            return material;
        }

        /// <summary>
        /// Material의 투명도를 변경한다.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Material SetAlpha(this Material material, float alpha)
        {
            if (material == null)
            {
                throw new ArgumentNullException(nameof(material));
            }
            Color color = material.color;
            color.a = alpha;
            material.color = color;
            return material;
        }
    }
}
