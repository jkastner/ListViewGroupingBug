using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewGroupingBug
{
  using System.Collections.ObjectModel;

  public class SomeItemGroup : ObservableCollection<SomeItem>
  {

    public string GroupName { get; } = "Group";

    public SomeItemGroup()
    {

    }
  }
}
