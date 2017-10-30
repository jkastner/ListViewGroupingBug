namespace ListViewGroupingBug
{
  using System;
  using System.Collections.ObjectModel;
  using System.Linq;

  using Xamarin.Forms;

  public class MainViewModel : BindableObject
  {
    
    public ObservableCollection<SomeItemGroup> ItemsGrouped { get; } = new ObservableCollection<SomeItemGroup>();

    public ObservableCollection<SomeItem> Items { get; } = new ObservableCollection<SomeItem>();

    public MainViewModel()
    {
      RemoveItemFromGroupCommand = new Command(RunRemoveFromGroup);
      RemoveItemCommand = new Command(RunRemove);
      ItemsGrouped.Add(new SomeItemGroup());

      AddItemToGroup(5);
      AddItemToSingle(5);
    }



    private void AddItemToGroup(int count)
    {
      while(count>0)
      {
        ItemsGrouped.First().Add(new SomeItem());
        count--;
      }
    }

    private void AddItemToSingle(int count)
    {
      while (count > 0)
      {
        Items.Add(new SomeItem());
        count--;
      }
    }

    private void RunRemoveFromGroup(object obj)
    {
      var asItem = obj as SomeItem;
      var match = this.ItemsGrouped.FirstOrDefault(x => x.Contains(asItem));
      match?.Remove(asItem);
    }

    private void RunRemove(object obj)
    {
      var asItem = obj as SomeItem;
      this.Items.Remove(asItem);
    }

    public Command RemoveItemCommand { get; set; }
    public Command RemoveItemFromGroupCommand { get; set; }
  }
}