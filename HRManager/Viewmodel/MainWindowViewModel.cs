using HRManager.ViewModel;
using HRManager.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManager.Viewmodel
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
    public RelayCommand RefreshCmd { get; set; }
    public RelayCommand CancelCmd { get; set; }

    public MainWindowViewModel()
    {
      RefreshCmd = new RelayCommand(
        execute: RefreshPeople,
        //canExecute : o => !isRefreshing 
        canExecute: CanRefresh
      );
      CancelCmd = new RelayCommand(
        execute: o => cancellationTokenSource.Cancel(),
        canExecute: CanCancel //o => isRefreshing
      );
    }

    private bool CanCancel(object obj)
    {
      return isRefreshing;
    }

    private async void RefreshPeople(object commandParameter)
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
    private bool CanRefresh(object obj)
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
          OnPropertyChanged(nameof(IsNotRefreshing));
          // ... à imaginer ...
          //OnPropertyChanged( vm => vm.IsNotRefreshing );
          RefreshCmd.FireExecuteChanged();
          CancelCmd.FireExecuteChanged();
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
