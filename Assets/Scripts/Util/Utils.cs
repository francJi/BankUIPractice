using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // FindChild : �Ķ���ͷ� �Է��� object�� �ڽĵ� ��, T component�� ������, name�� �̸��� ��ġ�� ������Ʈ�� ã�� ����.
    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (obj == null)
        {
        return null;
        }

        // recursive �� false���, �ڽ� �߿����� T component�� ���� �ڽ��� ã��.
        if (recursive == false)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                // GetChild�� �ش� �ε����� �ڽ� ������Ʈ transform�� ��ȯ��.
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
        // recurxsive�� true���, �� �̻� �ڽ��� ���� ������ Recursive�ϰ� T component�� ���� �ڽ��� ã��
        else
        {
            foreach (T component in obj.GetComponentsInChildren<T>()) // object�� ���� �ڽĵ� ��, T component�� �ִٸ�, T component�� ��� Array ���·� ��ȯ��Ų��.
            {
                if (string.IsNullOrEmpty (name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }

    // obj�� ������Ʈ ���� �� ������Ʈ�� ���,, transform�� ȣ��
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
