using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // FindChild : 파라미터로 입력한 object의 자식들 중, T component를 가지며, name과 이름이 일치한 오브젝트를 찾아 리턴.
    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (obj == null)
        {
        return null;
        }

        // recursive 가 false라면, 자식 중에서만 T component를 지닌 자식을 찾음.
        if (recursive == false)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                // GetChild는 해당 인덱스의 자식 오브젝트 transform을 반환함.
                Transform transform = obj.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        // recurxsive가 true라면, 더 이상 자식이 없을 때까지 Recursive하게 T component를 지닌 자식을 찾음
        else
        {
            foreach (T component in obj.GetComponentsInChildren<T>()) // object의 하위 자식들 중, T component가 있다면, T component를 모두 Array 형태로 반환시킨다.
            {
                if (string.IsNullOrEmpty (name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }

    // obj의 컴포넌트 없는 빈 오브젝트일 경우,, transform만 호출
    public static GameObject FindChild(GameObject obj, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(obj, name, recursive);
        if (transform == null)
        {
            return null;
        }

        return transform.gameObject;
    }
}
