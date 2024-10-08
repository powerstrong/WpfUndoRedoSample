using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

    public class TransactionalCompositeCommand : ICommand
    {
        private readonly SimulatorDbContext _context;
        private readonly List<ICommand> _commands = new();

        public TransactionalCompositeCommand(SimulatorDbContext context)
        {
            _context = context;
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void Execute()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var command in _commands)
                    {
                        command.Execute();
                    }
                    transaction.Commit(); // 모든 명령이 성공하면 트랜잭션을 완료
                }
                catch (Exception)
                {
                    // 에러 발생 시 모든 명령이 취소됩니다 (트랜잭션 롤백)
                    Unexecute();
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Unexecute()
        {
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Unexecute();
            }
        }
    }

}
