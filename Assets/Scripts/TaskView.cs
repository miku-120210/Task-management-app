using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class TaskView : MonoBehaviour
{
  [SerializeField] private TMP_InputField inputField;
  [SerializeField] private Button addButton;
  [SerializeField] private Transform taskContent;
  [SerializeField] private TaskItem taskItemPrefab;

  private TaskPresenter presenter;
  private ObjectPool<TaskItem> pool = new();
  private Dictionary<TaskModel, TaskItem> taskMap = new();

  private void Start()
  {
    presenter = new TaskPresenter(this);
    addButton.onClick.AddListener(OnAddButtonClick);
  }

  public void OnAddButtonClick()
  {
    if (!string.IsNullOrWhiteSpace(inputField.text))
    {
      presenter.AddTask(inputField.text);
      inputField.text = "";
    }
  }

  public void AddTaskItem(TaskModel model)
  {
    var item = pool.Get(taskItemPrefab, taskContent);
    item.Setup(model, presenter);
    taskMap[model] = item;
  }

  public void UpdateTaskItem(TaskModel model)
  {
    if (taskMap.TryGetValue(model, out var item))
    {
      item.Refresh();
    }
  }

  public void RemoveTaskItem(TaskModel model)
  {
    if (taskMap.TryGetValue(model, out var item))
    {
      pool.Release(item);
      taskMap.Remove(model);
    }
  }
}