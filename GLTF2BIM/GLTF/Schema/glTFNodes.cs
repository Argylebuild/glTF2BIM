﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using GLTF2BIM.Properties;

namespace GLTF2BIM.GLTF.Schema {
    /// <summary>
    /// 
    /// </summary>
    public sealed class glTFNodes : IEnumerable<glTFNode> {
        readonly List<glTFNode> _items = new List<glTFNode>();
        readonly Stack<glTFNode> _openItems = new Stack<glTFNode>();

        public glTFNode this[uint index] => _items[(int)index];

        public uint IndexOf(glTFNode node) => (uint)_items.IndexOf(node);

        public glTFNode Peek() => _openItems.Count > 0 ? _openItems.Peek() : null;

        public bool IsOpen() => _openItems.Count > 0;

        public uint Append(glTFNode item) {
            _items.Add(item);
            uint itemIndex = (uint)_items.Count - 1;
            glTFNode openItem = Peek();
            if (openItem is glTFNode parent) {
                if (parent.Children is null)
                    parent.Children = new HashSet<uint>();
                parent.Children.Add(itemIndex);
            }
            return itemIndex;
        }

        public void Open(uint idx) {
            if (_items.ElementAtOrDefault((int)idx) is glTFNode item)
                _openItems.Push(item);
            else
                throw new Exception(StringLib.ItemNotExist);
        }

        public void Close() {
            if (_openItems.Count > 0)
                _openItems.Pop();
        }

        public bool Contains(glTFNode node) => _items.Contains(node);

        public bool Contains(uint idx) => idx < _items.Count;

        public IEnumerator<glTFNode> GetEnumerator() {
            return new glTFNodesEnum(_items);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    class glTFNodesEnum : IEnumerator<glTFNode> {
        glTFNode[] _items;
        int position = -1;

        public glTFNodesEnum(List<glTFNode> items) => _items = items.ToArray();

        public glTFNode Current => _items[position];

        object IEnumerator.Current => Current;

        public void Dispose() {
            _items = null;
        }

        public bool MoveNext() {
            position++;
            return (position < _items.Length);
        }

        public void Reset() {
            position = -1;
        }
    }
}
