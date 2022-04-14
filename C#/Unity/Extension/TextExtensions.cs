using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KBluePurple.UsefulExtensions
{
    public static class TextExtensions
    {
        private static Dictionary<int, Coroutine> animationCoroutines = new Dictionary<int, Coroutine>();

        /// <summary>
        /// Text에 순차적으로 텍스트를 출력한다.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textToAnimate">출력할 글자</param>
        /// <param name="timePerChar">한 글자당 Sleep 시간</param>
        /// <param name="onCompleted">출력이 완료된 후 콜백</param>
        /// <returns></returns>
        public static WaitForSeconds AnimatedText(this Text text, string textToAnimate, float timePerChar, Action onCompleted = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (animationCoroutines.ContainsKey(text.GetInstanceID()))
            {
                DummyMonobehaviour.StopCorutine(animationCoroutines[text.GetInstanceID()]);
                animationCoroutines.Remove(text.GetInstanceID());
            }
            animationCoroutines[text.GetInstanceID()] = DummyMonobehaviour.StartCorutine(AnimatedTextCoroutine(text, textToAnimate, timePerChar, onCompleted));
            return new WaitForSeconds(textToAnimate.Length * timePerChar);
        }

        private static IEnumerator AnimatedTextCoroutine(Text text, string textToAnimate, float timePerChar, Action onCompleted)
        {
            text.text = "";
            for (int i = 0; i < textToAnimate.Length; i++)
            {
                text.text += textToAnimate[i];
                yield return new WaitForSeconds(timePerChar);
            }

            onCompleted?.Invoke();
        }
    }
}
