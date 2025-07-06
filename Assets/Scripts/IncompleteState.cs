using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncompleteState : ITaskState
{
    public string StateName => "未完了";
    public void Toggle(TaskModel task) => task.SetState(new CompleteState());
}
