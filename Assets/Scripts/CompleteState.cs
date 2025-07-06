using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteState : ITaskState
{
    public string StateName => "完了";
    public void Toggle(TaskModel task) => task.SetState(new IncompleteState());
}
