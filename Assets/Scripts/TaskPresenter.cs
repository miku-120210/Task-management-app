using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class TaskPresenter
{
  private readonly TaskView view;
  private readonly TaskFactory factory;
  private readonly List<TaskModel> tasks = new();

  public TaskPresenter(TaskView view)
  {
    this.view = view;
    factory = new TaskFactory();
  }

  public async void AddTask(string title)
  {
    await UniTask.Delay(500); // 疑似サーバー保存

    var task = factory.CreateTask(title);
    task.OnTaskChanged += view.UpdateTaskItem;
    tasks.Add(task);

    view.AddTaskItem(task);
  }

  public void ToggleTask(TaskModel task)
  {
    task.ToggleState();
  }

  public void RemoveTask(TaskModel task)
  {
    tasks.Remove(task);
    view.RemoveTaskItem(task);
  }
}