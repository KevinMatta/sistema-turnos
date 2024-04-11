using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.DataAccess.Repository
{
    interface IRepository<T>
    {
        public IEnumerable<T> List();
        public RequestStatus Insert(T item);
        public RequestStatus Update(T item);
        public RequestStatus Delete(int? id);
        public T Details(int? id);
        public T find(int? id);
    }
}
