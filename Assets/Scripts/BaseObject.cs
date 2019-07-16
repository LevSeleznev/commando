using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс для кэширования
/// </summary>
public abstract class BaseObject : MonoBehaviour
{
    protected Transform _GOTransform;
    protected GameObject _GOInstance;
    protected string _name;
    protected bool _isVisible;

    protected Vector3 _position;
    protected Vector3 _scale;
    protected Quaternion _rotation;

    protected Material _material;
    protected Color _color;

    protected Rigidbody _rigidbody;

    #region UnityFunctions
    protected virtual void Awake()
    {
        _GOInstance = gameObject;
        _name = _GOInstance.name;
        _GOTransform = _GOInstance.transform;

        if(GetComponent<Rigidbody>())
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        if(GetComponent<Renderer>())
        {
            _material = GetComponent<Renderer>().material;
        }
    }
    #endregion

    /// <summary>
    /// Ссылка на объект
    /// </summary>
    public GameObject InstanceObject
    {
        get { return _GOInstance; }
    }

    /// <summary>
    /// Имя объекта
    /// </summary>
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            InstanceObject.name = _name;
        }
    }

    /// <summary>
    /// Имя объекта
    /// </summary>
    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            if(_GOInstance.GetComponent<MeshRenderer>())
            {
                _GOInstance.GetComponent<MeshRenderer>().enabled = _isVisible;
            }
        }
    }

    /// <summary>
    /// Позиция Объекта
    /// </summary>
    public Vector3 Position
    {
        get
        {
            if (_GOInstance)
            {
                _position = _GOTransform.position;
            }
            return _position;
        }
        set
        {
            _position = value;
            if (_GOInstance)
            {
                _GOTransform.position = _position;
            }
        }
    }

    /// <summary>
    /// Размер Объекта
    /// </summary>
    public Vector3 Scale
    {
        get
        {
            if (_GOInstance)
            {
                _scale = _GOTransform.localScale;
            }
            return _scale;
        }
        set
        {
            _scale = value;
            if (_GOInstance)
            {
                _GOTransform.localScale = _scale;
            }
        }
    }

    /// <summary>
    /// Поворот Объекта
    /// </summary>
    public Quaternion Rotation
    {
        get
        {
            if (_GOInstance)
            {
                _rotation = _GOTransform.rotation;
            }
            return _rotation;
        }
        set
        {
            _rotation = value;
            if (_GOInstance)
            {
                _GOTransform.rotation = _rotation;
            }
        }
    }

    /// <summary>
    /// Материал
    /// </summary>
    public Material GetMaterial
    {
        get { return _material; }
    }

    /// <summary>
    /// Ссылка на физическое тело
    /// </summary>
    public Rigidbody GetRB
    {
        get { return _rigidbody; }
    }
}