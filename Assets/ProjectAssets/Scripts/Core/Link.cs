using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Link<T>
{
    T _ref;
    
    public T Value {
        get {
            return _ref;
        }
        set {
            _ref = value;
        }
    }
}
