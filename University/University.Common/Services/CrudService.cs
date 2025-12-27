using System;
using System.Collections.Generic;
using System.Linq;
using University.Common.Models;

namespace University.Common.Services
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly List<T> _items = new();

        public void Create(T element)
        {
            _items.Add(element);
        }

        public T Read(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _items;
        }

        public void Update(T element)
        {
            var index = _items.FindIndex(x => x.Id == element.Id);
            if (index >= 0)
                _items[index] = element;
        }

        public void Remove(T element)
        {
            _items.Remove(element);
        }
    }
}
