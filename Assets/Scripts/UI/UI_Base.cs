using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objectsDict = new Dictionary<Type, UnityEngine.Object[]>();

    protected bool _init = false;

    protected virtual bool Init()
    {
        if (_init)
        {
            return false;
        }
        return _init = true;
    }
    // �� type�� �̸��� �ش��ϴ� enum Ŭ������ ������Ʈ���� �̸��� ����.
    // �̸� ��������, _objectsDict �� value�� key(�ش� type)�� ���� ������Ʈ���� ����.
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // Enum.GetNames �޼��� ȣ���, �Ķ���ͷ� �ѱ� Enum Ŭ������ ��ҵ��� string[] ���� ����
        string[] names = Enum.GetNames(type);
        // Object�� �迭�� value ��. ���� Ű��(Type)���� ȣ���� ��ҵ� = �ش� type�� object�� �̸���
        var objs = new UnityEngine.Object[names.Length]; 
        _objectsDict.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objs[i] = Utils.FindChild(gameObject, names[i], true);
            }
           else
            {
                objs[i] = Utils.FindChild<T>(gameObject, names[i], true);
            }

            if (objs[i] == null)
            {
                Debug.Log($"Failed to binding {names[i]}");
            }
        }
    }

    protected void BindObject(Type type) { Bind<GameObject>(type); }
    protected void BindPanel(Type type) { Bind<GameObject>(type); }
    protected void BindImage(Type type) { Bind<Image>(type); }
    protected void BindText(Type type) { Bind<TextMeshProUGUI>(type); }
    protected void BindButton(Type type) { Bind<Button>(type); }

    // ���� Dictionary _objectsDict���� �ش� Type�� idx ��° object�� ��������
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objectsDict.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        return objects[idx] as T;
    }

    protected GameObject GetObject(int idx) 
    { 
        return Get<GameObject>(idx); 
    }
    protected Text GetText(int idx) 
    { 
        return Get<Text>(idx); 
    }
    protected TextMeshProUGUI GetTextMesh(int idx)
    {
        return Get<TextMeshProUGUI>(idx);
    }
    protected Button GetButton(int idx) 
    { 
        return Get<Button>(idx); 
    }
    protected Image GetImage(int idx) 
    { 
        return Get<Image>(idx); 
    }

    public static void BindEvent(GameObject obj, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(obj);
        evt.OnClickHandler += action;
    }
}

