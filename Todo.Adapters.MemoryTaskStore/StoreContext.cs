﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Todo.Entities;
using Todo.Ports.Entities;

namespace Todo.Adapters.MemoryTaskStore;

public class StoreContext
{
    public StoreContext()
    {
        Tasks = new Collection<ITask>
        {
            Task.Load(new Guid("3b35f11e-7080-45e2-a152-afff5a325508"), "Fork the repository", true),
            Task.Load(new Guid("4b2f8170-c618-4cd6-91b9-25e3b2bfa53e"), "Clone the repository", true),
            Task.Load(new Guid("360644f3-abb5-410b-939d-78a6d07bd075"), "Create a branch", true),
            Task.Load(new Guid("f1f0adf8-255f-45ef-9528-d6c2c326240b"), "Make necessary changes and commit those changes", false),
            Task.Load(new Guid("72af359b-48d7-41cd-978b-38c82e1206d4"), "Push changes to GitHub", false),
            Task.Load(new Guid("e3da5d74-3fa4-4856-b0dd-d098e0f637ed"), "Submit your changes for review", false),
            Task.Load(new Guid("1798c99c-371e-497c-a529-a1e3667b9ece"), "Keeping your fork synced with this repository", false)
        };
    }

    public ICollection<ITask> Tasks { get; }
}
