using System;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "SO/Variables/Float Variable", order = 0)]
    public class RuntimeFloatVariable : ScriptableObject
    {
        [SerializeField] float InitialValue;
        public float RuntimeValue { get => _runtimeValue; set { _runtimeValue = value; ValueChanged?.Invoke(); } }
        float _runtimeValue;

        public event Action ValueChanged;

        void OnEnable()
        {
            _runtimeValue = InitialValue;
        }
    }
}