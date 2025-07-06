using System;

public class TaskModel
{
    public string Title { get; private set; }
    public ITaskState State { get; private set; }

    public event Action<TaskModel> OnTaskChanged;

    public TaskModel(string title)
    {
        Title = title;
        State = new IncompleteState();
    }

    public void ToggleState()
    {
        State.Toggle(this);
        OnTaskChanged?.Invoke(this);
    }

    public void SetState(ITaskState state)
    {
        State = state;
    }
}
