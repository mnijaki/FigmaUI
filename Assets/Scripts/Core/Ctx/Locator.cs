namespace MN.Core.Ctx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Locator<TBase>
    {
        private Dictionary<Type, Dictionary<string, TBase>> _items = new();

        /// <summary>
        ///   Add item based on on it type.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        /// <exception cref="Exception"></exception>
        public void AddItem(TBase item, string key = "")
        {
            Type type = GetLowestType(item.GetType());
            if (!_items.ContainsKey(type))
            {
                _items[type] = new Dictionary<string, TBase>();
            }

            if (!_items[type].ContainsKey(key))
            {
                _items[type][key] = item;
            }
            else
            {
                throw new Exception($"Item of type {type.Name} with key '{key}' already exists.");
            }
        }

        /// <summary>
        ///   Retrieve item based on it type. 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TItem GetItem<TItem>(string key = "") where TItem : TBase
        {
            Type type = GetLowestType(typeof(TItem));

            if (type.IsInterface)
            {
                throw new Exception ($"Cannot get item of type {type.Name}. Interfaces are not allowed for this particular method.");
            }
            
            if (_items.ContainsKey(type) && _items[type].ContainsKey(key))
            {
                return (TItem)_items[type][key];
            }
            
            return default;
        }

        /// <summary>
        ///   Check if locator have Item of given type.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public bool HasItem<TItem>(string key = "") where TItem : TBase
        {
            return GetItem<TItem>(key) != null;
        }

        /// <summary>
        ///   Remove item from Locator based on its type.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <exception cref="Exception"></exception>
        public void RemoveItem<TItem>(string key = "") where TItem : TBase
        {
            Type type = GetLowestType(typeof(TItem));

            if (type.IsInterface)
            {
                throw new Exception ($"Cannot get item of type {type.Name}. Interfaces are not allowed for this particular method.");
            }
            
            if (_items.ContainsKey(type) && _items[type].ContainsKey(key))
            {
                _items[type].Remove(key);
            }
            else
            {
                throw new Exception($"Item of type {type.Name} with key '{key}' does not exist.");
            }
        }
        
        private static Type GetLowestType(Type type)
        {
            return GetTypeHierarchy(type).LastOrDefault();
        }
        
        private static IEnumerable<Type> GetTypeHierarchy(Type type)
        {
            List<Type> hierarchy = new();
            while (type != null)
            {
                // Insert at the beginning to maintain order
                hierarchy.Insert(0, type); 
                type = type.BaseType;
            }

            return hierarchy.ToArray();
        }
    }
}
