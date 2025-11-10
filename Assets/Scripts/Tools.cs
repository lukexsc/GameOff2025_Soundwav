using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Tools
{
	public static int Wrap (int value, int minInclusive, int maxInclusive)
	{
        int inValue = value - minInclusive;
        int calc = (inValue % (maxInclusive + 1 - minInclusive)) + minInclusive;
        return (calc < minInclusive) ? maxInclusive + calc + 1 - minInclusive : calc;
    }

    public static void SetHeight(this Rect rect, float height)
    {
        rect.Set(rect.x, rect.y, rect.width, height);
    }

    public static void MarkDirty(GameObject obj)
    {
#if UNITY_EDITOR

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(obj.scene);

#endif
    }

    /// <summary>
    /// Frame-Independent Exponential Decay
    /// </summary>
    /// <param name="a">Starting Value</param>
    /// <param name="b">Ending Value</param>
    /// <param name="decay">Useful range ~1-25 from slow to fast</param>
    /// <param name="time">Usually Time.deltaTime</param>
    /// <returns></returns>
    public static float expDecay(float a, float b, float decay, float time)
    {
        return b + ((a - b) * Mathf.Exp(-decay * time));
    }

    /// <summary>
    /// Frame-Independent Exponential Decay
    /// </summary>
    /// <param name="a">Starting Value</param>
    /// <param name="b">Ending Value</param>
    /// <param name="decay">Useful range ~1-25 from slow to fast</param>
    /// <param name="time">Usually Time.deltaTime</param>
    /// <returns></returns>
    public static Vector2 expDecay(Vector2 a, Vector2 b, float decay, float time)
    {
        return b + ((a - b) * Mathf.Exp(-decay * time));
    }

    /// <summary>
    /// Frame-Independent Exponential Decay
    /// </summary>
    /// <param name="a">Starting Value</param>
    /// <param name="b">Ending Value</param>
    /// <param name="decay">Useful range ~1-25 from slow to fast</param>
    /// <param name="time">Usually Time.deltaTime</param>
    /// <returns></returns>
    public static Vector3 expDecay(Vector3 a, Vector3 b, float decay, float time)
    {
        return b + ((a - b) * Mathf.Exp(-decay * time));
    }

    /// <summary>
    /// Frame-Independent Exponential Decay
    /// </summary>
    /// <param name="a">Starting Value</param>
    /// <param name="b">Ending Value</param>
    /// <param name="decay">Useful range ~1-25 from slow to fast</param>
    /// <param name="time">Usually Time.deltaTime</param>
    /// <returns></returns>
    public static Color expDecay(Color a, Color b, float decay, float time)
    {
        return b + ((a - b) * Mathf.Exp(-decay * time));
    }
}

//
// Classes
//

[System.Serializable]
public abstract class InterfaceField
{
    [SerializeField] protected GameObject obj;

    public abstract bool HasComponentOfType(GameObject go);
    public abstract string GetInterfaceName();
    public abstract void Initialize();
    public bool ObjIsNull => obj == null;
    public bool ObjIsNotNull => obj != null;
}

//
// Optional
//

[System.Serializable]
public abstract class OptionalParent { }

public class Optional<T> : OptionalParent
{
    [SerializeField] private bool enabled;
    [SerializeField] private T _value;

    public bool Enabled
    {
        get { return enabled; }
        set { enabled = value; }
    }
    public T Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Optional()
    {
        enabled = false;
    }
    public Optional(T initValue)
    {
        if (initValue == null) return;
        enabled = true;
        _value = initValue;
    }

    public static implicit operator T(Optional<T> t) { return t.Value; }
}

[System.Serializable] public class OptionalInt : Optional<int> { }
[System.Serializable] public class OptionalFloat : Optional<float> { }
[System.Serializable] public class OptionalTransform : Optional<Transform> { }
[System.Serializable] public class OptionalGameObject : Optional<GameObject> { }
[System.Serializable] public class OptionalVector2 : Optional<Vector2> { }
[System.Serializable] public class OptionalVector3 : Optional<Vector3> { }

//
// Disabled
//

[System.Serializable]
public abstract class DisabledParent { }

public class Disabled<T> : DisabledParent
{
    [SerializeField] private T _value;
    
    public T Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Disabled() { }
    public Disabled(T initValue)
    {
        _value = initValue;
    }

    public static implicit operator T(Disabled<T> t) { return t.Value; }
}

[System.Serializable] public class DisabledSpriteRenderer : Disabled<SpriteRenderer> { }
[System.Serializable] public class DisabledRectTransform : Disabled<RectTransform> { }