using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIinstance;

    int _order = 10;
    public void Awake()
    {
        UIinstance = this;
    }
    public UI_Scene SceneUI { get; private set; }
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null) 
            {
                root = new GameObject { name = "@UI_Root" };
            }
            return root;
        }
    }

    public void SetCanvas(GameObject obj, bool sort = true) // sort의 default 값을 true로 간주.
    {
        Canvas canvas = Utils.GetOrAddComponent<Canvas>(obj);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        Debug.Log(name); //
        GameObject obj = Instantiate(Resources.Load<GameObject>($"Prefabs/Scene/{name}"));
        T sceneUI = Utils.GetOrAddComponent<T>(obj);
        SceneUI = sceneUI;

        obj.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null, Transform parent = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject prefab = Instantiate(Resources.Load<GameObject>($"Prefabs/Popup/{name}"));
        GameObject obj = Instantiate(Resources.Load<GameObject>($"Prefabs/Popup/{name}"));
        T popup = Utils.GetOrAddComponent<T>(obj);
        _popupStack.Push(popup);

        if (parent != null)
        {
            obj.transform.SetParent(parent);
        }
        else if (SceneUI != null)
        {
            obj.transform.SetParent(SceneUI.transform);
        }
        else
        {
            obj.transform.SetParent(Root.transform);
        }

        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = prefab.transform.position;

        return popup;
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/SubItem/{name}");

        GameObject obj = Instantiate(prefab, parent);
        obj.name = prefab.name;

        if (parent != null)
        {
            obj.transform.SetParent(parent);
        }

        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = prefab.transform.position;

        return Utils.GetOrAddComponent<T>(obj);
    }
}
