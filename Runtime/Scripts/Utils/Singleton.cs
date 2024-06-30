using UnityEngine;

namespace Uralstech.UGemini.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T s_instance;

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
