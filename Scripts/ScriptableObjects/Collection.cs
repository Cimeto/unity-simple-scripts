using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// The Collection ScriptableObject permit the generation of other Assets collections (AudioClipCollection, SpriteCollection, ...) 
    /// That work very similarly to a List<T>, but allows to use Random gets and access an asset by its name.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Collection<T> : ScriptableObject
    {
        public List<T> Elements;

        public int Count => Elements.Count;
        public T Random => Elements[UnityEngine.Random.Range(0, Elements.Count)];

        private int index;

        public T Next()
        {
            if (Elements == null || Elements.Count == 0) { return default; }
            index = (index + 1) > (Elements.Count - 1) ? 0 : index + 1;
            return Elements[index];
        }

        public T Get(string name)
        {
            if (Elements == null || Elements.Count == 0) { return default; }
            if (Elements[0].GetType().GetProperty("name") == null) { return default; }

            for (int i = 0; i < Elements.Count; i++)
            {
                if ((string)GetPropValue(Elements[i], "name") == name) { return Elements[i]; }
            }

            return default;
        }

        public object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}