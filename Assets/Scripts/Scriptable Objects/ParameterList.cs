using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Parameter List", menuName = "ParameterList")]
public class ParameterList : ScriptableObject {

    public Parameter[] parameters;

    [System.Serializable]
    public struct Parameter {

        public enum ParameterType { Category, Number, Range, Boolean, Color, Gradient };
        public string name;
        public ParameterType type;
        public float min, max;
        public string propertyName;
    }

}