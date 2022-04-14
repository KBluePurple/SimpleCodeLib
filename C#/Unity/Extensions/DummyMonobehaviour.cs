using System.Collections;

namespace KBluePurple.UsefulExtensions
{
    public class DummyMonobehaviour : MonoBehaviour
    {
        #region static members

        private static DummyMonobehaviour dummy = null;
        private static DummyMonobehaviour Dummy
        {
            get
            {
                if (dummy == null)
                {
                    dummy = new GameObject("KBluePurple.UsefulExtensions").AddComponent<DummyMonobehaviour>();
                    dummy.gameObject.hideFlags = HideFlags.HideAndDontSave;
                }
                return dummy;
            }
        }

        public static Coroutine StartCorutine(IEnumerator corutine)
        {
            return Dummy.StartCoroutine(corutine);
        }

        public static void StopCorutine(Coroutine corutine)
        {
            Dummy.StopCoroutine(corutine);
        }

        #endregion

        #region instance members

        void Awake()
        {
            dummy = this;
            DontDestroyOnLoad(this);
        }

        #endregion
    }
}
