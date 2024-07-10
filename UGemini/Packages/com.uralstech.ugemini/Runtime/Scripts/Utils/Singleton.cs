using UnityEngine;

namespace Uralstech.UGemini.Utils.Singleton
{
    /// <summary>
    /// Utility class to make inheriting types singletons.
    /// </summary>
    /// <typeparam name="T">The type to be made a singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T s_instance;

        /// <summary>
        /// The active instance of type <typeparamref name="T"/>.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (s_instance != null)
                    return s_instance;

                T[] objects = FindObjectsOfType<T>();
                if (objects.Length > 0)
                    s_instance = objects[0];

                if (objects.Length > 1)
                {
                    for (int i = 1; i < objects.Length; i++)
                        Destroy(objects[i]);
                }

                return s_instance ??= new GameObject(typeof(T).Name).AddComponent<T>();
            }
        }
    }
}
