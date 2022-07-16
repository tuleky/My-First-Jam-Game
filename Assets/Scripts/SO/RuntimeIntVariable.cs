using System;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "SO/Variables/Int Variable", order = 0)]
    public class RuntimeIntVariable : ScriptableObject
    {
        [SerializeField] int _initialValue;
        public int RuntimeValue { get => _runtimeValue; set { _runtimeValue = value; ValueChanged?.Invoke(); } }
        [NonSerialized] int _runtimeValue;

        public event Action ValueChanged;

        void OnEnable()
        {
            ResetValue();
        }

        public void ResetValue()
        {
            RuntimeValue = _initialValue;
        }
    }
}