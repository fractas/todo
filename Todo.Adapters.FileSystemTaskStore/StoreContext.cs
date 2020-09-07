using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Todo.Adapters.FileSystemTaskStore.DependencyInjection;
using Todo.Entities;

namespace Todo.Adapters.FileSystemTaskStore
{
    public class StoreContext : IDisposable
    {
        private readonly string _path;

        private readonly ICollection<ITask> _tasks = new Collection<ITask>();

        public StoreContext(ApplicationConfiguration app)
        {
            _path = app.Filename;

            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path));

                File.Create(_path);
            }
        }

        public ICollection<ITask> Tasks
        {
            get
            {
                if (!_tasks.Any())
                {
                    try
                    {
                        foreach (string line in File.ReadAllLines(_path))
                        {
                            string[] args = line.Split(';', StringSplitOptions.None);

                            if (args.Length < 3)
                            {
                                throw new FormatException("DataRecord format invalid");
                            }

                            _tasks.Add(Task.Load
                                (
                                    Guid.Parse(args.ElementAt(0)),
                                    args.ElementAt(1),
                                    bool.Parse(args.ElementAt(2))
                                ));
                        }
                    }
                    catch
                    {
                        // ignore
                    }
                }

                return _tasks;
            }
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    try
                    {
                        File.WriteAllLines(_path, _tasks.Select(s => $"{s.Id};{s.Description};{s.Done}"));
                    }
                    catch
                    {
                        // ignore
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }
    }
}
