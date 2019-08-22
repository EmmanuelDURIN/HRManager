using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRManager.ViewModels
{
    public class MainWindowViewModel : BindableBase
  {
    private CancellationTokenSource cancellationTokenSource;
    private bool isRefreshing;
    // propb + tab x 2
    private Person selectedPerson;
    // Bonne pratique d'initialiser les collections tôt,
    // Ctrl + ; pour amener le using
    private ObservableCollection<Person> people = new ObservableCollection<Person>();
    public DelegateCommand RefreshCmd { get; set; }
    public DelegateCommand CancelCmd { get; set; }

    public MainWindowViewModel()
    {
      RefreshCmd = new DelegateCommand(
        RefreshPeople,
        //canExecute : o => !isRefreshing 
        CanRefresh
      );
      CancelCmd = new DelegateCommand(
        () => cancellationTokenSource.Cancel(),
        CanCancel //o => isRefreshing
      );
    }

    private bool CanCancel()
    {
      return isRefreshing;
    }

    private async void RefreshPeople()
    {
      IsRefreshing = true;
      people.Clear();

      cancellationTokenSource = new CancellationTokenSource();
      // bloque le thread graphique : Thread.Sleep(3000);
      Task task = Task.Delay(3000, cancellationTokenSource.Token);
      //System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
      //Task<HttpResponseMessage> responseTask = client.GetAsync("http://?....");
      //HttpResponseMessage response = await responseTask;
      // bloque le thread graphique : task.Wait();
      try
      {
        await task; // await est un mot clé de C# 5 
        IEnumerable<Person> newPeople = Enumerable.Range(1, 10)
          .Select(i => new Person()
          {
            Firstname = "Firstname" + i,
            Lastname = "Lastname" + i,
            Age = 20 + i,
          }
          );
        foreach (var person in newPeople)
        {
          people.Add(person);
        }
      }
      catch (Exception ex)
      {
        // exception probablement due à l'annulation
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      IsRefreshing = false;
    }
    private bool CanRefresh()
    {
      return !isRefreshing;
    }
    internal void HireEmployee(Person person)
    {
      people.Add(person);
    }
    #region Propriétés
    public bool IsNotRefreshing
    {
      get { return !isRefreshing; }
    }
    public bool IsRefreshing
    {
      get { return isRefreshing; }
      set
      {
        bool hasChanged = SetProperty(ref isRefreshing, value);
        if (hasChanged)
        {
          // Correct, mais peut être victime d'un refactoring
          //OnPropertyChanged("IsNotRefreshing");
          // ... en C#6 : 
          RaisePropertyChanged(nameof(IsNotRefreshing));
          // ... à imaginer ...
          //OnPropertyChanged( vm => vm.IsNotRefreshing );
          RefreshCmd.RaiseCanExecuteChanged();
          CancelCmd.RaiseCanExecuteChanged();
        }
      }
    }
    public Person SelectedPerson
    {
      get { return selectedPerson; }
      set
      {
        // Appel à BindableBase.SetProperty qui émet un évt consommé par l'IHM
        SetProperty(ref selectedPerson, value);
      }
    }
    public ObservableCollection<Person> People
    {
      get { return people; }
      set { SetProperty(ref people, value); }
    }
    #endregion
  }
}
