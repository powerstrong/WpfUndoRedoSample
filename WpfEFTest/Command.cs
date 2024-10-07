using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEFTest.Data;

namespace WpfEFTest
{
    public interface ICommand
    {
        void Execute();
        void Unexecute(); // 이 메서드를 통해 Undo를 수행
    }

    public class AddCommand<T> : ICommand where T : class
    {
        private readonly SimulatorDbContext _context;
        private readonly T _entity;

        public AddCommand(SimulatorDbContext context, T entity)
        {
            _context = context;
            _entity = entity;
        }

        public void Execute()
        {
            _context.Set<T>().Add(_entity);
            _context.SaveChanges();
        }

        public void Unexecute()
        {
            _context.Set<T>().Remove(_entity);
            _context.SaveChanges();
        }
    }

    public class DeleteCommand<T> : ICommand where T : class
    {
        private readonly SimulatorDbContext _context;
        private readonly T _entity;

        public DeleteCommand(SimulatorDbContext context, T entity)
        {
            _context = context;
            _entity = entity;
        }

        public void Execute()
        {
            _context.Set<T>().Remove(_entity);
            _context.SaveChanges();
        }

        public void Unexecute()
        {
            _context.Set<T>().Add(_entity);
            _context.SaveChanges();
        }
    }

}
