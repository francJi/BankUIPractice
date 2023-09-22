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
    // 각 type의 이름에 해당하는 enum 클래스에 오브젝트들의 이름을 정의.
    // 이를 기준으로, _objectsDict 의 value에 key(해당 type)를 가진 오브젝트들을 저장.
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // Enum.GetNames 메서드 호출시, 파라미터로 넘긴 Enum 클래스의 요소들을 string[] 으로 리턴
        string[] names = Enum.GetNames(type);
        // Object의 배열이 value 값. 위의 키값(Type)으로 호출한 요소들 = 해당 type의 object의 이름들
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

    // 위의 Dictionary _objectsDict에서 해당 Type의 idx 번째 object를 가져오기
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

