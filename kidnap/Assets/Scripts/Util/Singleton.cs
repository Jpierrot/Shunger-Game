using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static bool m_ShuttingDown = false;
        private static object m_Lock = new object();
        private static T m_Instance;

        /// <summary>
            /// 이 프로퍼티를 통해서 싱글톤을 붙임
            /// </summary>
        public static T Instance
        {
            get
            {
                if (m_ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                    return null;
                }

                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        // 인스턴스 존재 유무 탐색
                        m_Instance = (T)FindObjectOfType(typeof(T));

                        // 없다면 새로 만듬
                        if (m_Instance == null)
                        {
                            // 오브젝트를 싱글톤화 시킴
                            var singletonObject = new GameObject();
                            m_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            // 씬에서 파괴되지 않도록 설정
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return m_Instance;
                }
            }
        }
        private void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }


        private void OnDestroy()
        {
            m_ShuttingDown = true;
        }
    }


}

