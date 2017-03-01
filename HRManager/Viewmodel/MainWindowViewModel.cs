using HRManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Viewmodel
{
  public class MainWindowViewModel : BindableBase
  {
    // propb + tab x 2
    private Person selectedPerson;
    public Person SelectedPerson
    {
      get { return selectedPerson; }
      set
      {
        // Appel à BindableBase.SetProperty qui émet un évt consommé par l'IHM
        SetProperty(ref selectedPerson, value);
      }
    }
    // propb(ou propfull) + tab x 2
    // Bonne pratique d'initialiser les collections tôt,
    //
    // Ctrl + ; pour amener le using
    private ObservableCollection<Person> people 
      = new ObservableCollection<Person> ();

    public ObservableCollection<Person> People
    {
      get { return people; }
      set { SetProperty(ref people, value); }
    }

    internal void HireEmployee(Person person)
    {
      people.Add(person);
    }
  }
}
