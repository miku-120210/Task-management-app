using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI titleText;
  [SerializeField] private TextMeshProUGUI stateText;
  [SerializeField] private Button toggleButton;
  [SerializeField] private Button deleteButton;

  private TaskModel model;
  private TaskPresenter presenter;

  public void Setup(TaskModel model, TaskPresenter presenter)
  {
    this.model = model;
    this.presenter = presenter;
    Refresh();

    toggleButton.onClick.AddListener(() => presenter.ToggleTask(model));
    deleteButton.onClick.AddListener(() => presenter.RemoveTask(model));
  }

  public void Refresh()
  {
    titleText.text = model.Title;
    stateText.text = model.State.StateName;
    
    if (model.State is IncompleteState)
    {
      stateText.color = Color.red;
    }
    else if (model.State is CompleteState)
    {
      stateText.color = new Color(0.1303065f,0.735849f,0.1214845f,1f);
    }
    
    RebuildLayout();
  }
  
  private void RebuildLayout()
  {
    LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
  }
}