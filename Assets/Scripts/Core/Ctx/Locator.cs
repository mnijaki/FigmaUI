namespace MN.Core.Ctx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Locator<TBase>
    {
        private readonly Dictionary<Type, TBase> _items = new();

        /// <summary>
        ///   Add item based on on it type.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void AddItem(TBase item)
        {
            Type type = GetLowestType(item.GetType());
            if (_items.ContainsKey(type))
            {
                throw new Exception($"Item of type {type.Name} already exists in Locator.");
            }
            
            _items[type] = item;
        }

        /// <summary>
        ///   Retrieve item based on it type.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TItem GetItem<TItem>() where TItem : TBase
        {
            Type type = GetLowestType(typeof(TItem));
            if (type.IsInterface)
            {
                throw new Exception ($"Cannot get item of type {type.Name}. Interfaces are not allowed for this particular method.");
            }
            
            if (_items.TryGetValue(type, out TBase item))
            {
                return (TItem)item;
            }
            
            return default;
        }

        /// <summary>
        ///    Check if locator have Item of given type.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public bool HasItem<TItem>() where TItem : TBase
        {
            return GetItem<TItem>() != null;
        }

        /// <summary>
        ///   Remove item from Locator based on its type.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <exception cref="Exception"></exception>
        public void RemoveItem<TItem>() where TItem : TBase
        {
            Type type = GetLowestType(typeof(TItem));
            if (type.IsInterface)
            {
                throw new Exception ($"Cannot get item of type {type.Name}. Interfaces are not allowed for this particular method.");
            }
            
            if (_items.ContainsKey(type))
            {
                _items.Remove(type);
            }
            else
            {
                throw new Exception($"Item of type {type.Name} does not exist in Locator.");
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
