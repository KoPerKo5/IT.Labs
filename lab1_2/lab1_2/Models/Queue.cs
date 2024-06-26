﻿using lab1_3.Models;

namespace lab1_3
{
    public class Queue : IQueue
    {
        #region Fields
        const Int32 N = 10;

        private List<String> _items;
        private Int32 _count;
        #endregion

        #region Constructors
        public Queue()
        {
            _items = new List<String>();
        }
        #endregion

        #region Realization
        public void Add(String item)
        {
            if (_items.Contains(item))
            {
                return;
            }

            _items.Add(item);
        }

        public String Remove()
        {
            if (_count == 0)
            {
                return "";
            }

            String item = _items[0];
            _items.Remove(item);
            --_count;
            return item;
        }

        public void Clear()
        {
            _count = 0;
            _items.Clear();
        }
        #endregion

        #region Properties
        public Boolean IsEmpty
        {
            get => _count == 0;
        }

        public Int32 Count
        {
            get => _count;
        }
        #endregion
    }
}
