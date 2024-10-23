using System.Collections.Generic;

namespace BehaviorTree
{
    public class Blackboard
    {
        public Dictionary<string, object> _data = new();

        public void SetValue<T>(string key, T value)
        {
            _data[key] = value;
        }

        public void RemoveKey(string key)
        {
            if (HasKey(key))
                _data.Remove(key);
        }

        public T GetValue<T>(string key)
        {
            return _data.TryGetValue(key, out object value) ? (T)value : default;
        }

        public bool HasKey(string key)
        {
            return _data.ContainsKey(key);
        }
    }
}