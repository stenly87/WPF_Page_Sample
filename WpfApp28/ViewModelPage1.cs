using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfApp28
{
    public class ViewModelPage1: Mvvm1125.MvvmNotify
    {
        private Model model;
        private readonly PageContainer pageContainer;

        public ObservableCollection<Person> People { get; set; }
        public Person SelectedPerson { get; set; }

        public Mvvm1125.MvvmCommand CreatePerson { get; set; }
        public Mvvm1125.MvvmCommand EditPerson { get; set; }

        public ViewModelPage1(Model model, PageContainer pageContainer)
        {
            this.model = model;
            model.PeopleChanged += Model_PeopleChanged;
            People = new ObservableCollection<Person>(model.GetPeople());
            this.pageContainer = pageContainer;
            CreatePerson = new Mvvm1125.MvvmCommand(
                ()=> {
                    pageContainer.CreatePagePersonEdit();
                },
                ()=> true);
            EditPerson = new Mvvm1125.MvvmCommand(
                ()=> {
                    pageContainer.CreatePagePersonEdit(SelectedPerson);
                },
                ()=> SelectedPerson != null);
        }

        private void Model_PeopleChanged(object sender, EventArgs e)
        {
            People = new ObservableCollection<Person>(model.GetPeople());
            NotifyPropertyChanged("People");
        }
    }
}