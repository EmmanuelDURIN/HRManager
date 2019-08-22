using Prism.Mvvm;

namespace HRManager
{
    // BindableBase Permet d'émettre des évts lors des modifs des propriétés

    public class Person : BindableBase
  {
    private int age;
    public int Age
    {
      get { return age; }
      set
      {
        SetProperty(ref age, value);
      }
    }
    private string firstname;
    public string Firstname
    {
      get { return firstname; }
      set
      {
        SetProperty(ref firstname, value);
      }
    }
    private string lastname;
    public string Lastname
    {
      get { return lastname; }
      set
      {
        SetProperty(ref lastname, value);
      }
    }
    public override string ToString()
    {
      return firstname + " " + lastname;
    }
  }
}
