using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITaskState
{
    string StateName { get; }
    void Toggle(TaskModel task);
}
