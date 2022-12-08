using System;
using Student.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Student.API.Services
{
    public interface IServices<Entity>
    {
        public void Add(Entity value);
        public void Remove(Guid value);
        public void Update(Entity value);
        public IEnumerable<Entity> GetList();

        public Entity GetByID(Guid value);
    }
    public class StudentServices : IServices<Students>
    {
        public readonly List<Students> students = new List<Students>();
        public void Add(Students value)
        {
            value.Id = Guid.NewGuid();
            students.Add(value);
        }

        public Students GetByID(Guid value)
        {
            return students.Where(x => x.Id == value).FirstOrDefault();
        }

        public IEnumerable<Students> GetList()
        {
            return students;
        }

        public void Remove(Guid value)
        {
            var _student =students.IndexOf(GetByID(value));
            students.RemoveAt(_student);
        }

        public void Update(Students value)
        {
            var _students = GetByID(value.Id);
            if (_students != null)
            {
                _students.Name = value.Name;
                _students.Description = value.Description;
            }
        }

    }
}
