using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory
{
    public TaskModel CreateTask(string title)
    {
        return new TaskModel(title);
    }
}
