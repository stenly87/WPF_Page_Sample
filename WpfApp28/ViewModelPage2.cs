using System;

namespace WpfApp28
{
    public class ViewModelPage2
    {
        public string LastName { 
            get => selectedPerson.LastName;
            set {
                selectedPerson.LastName = value;
            }
        }
        public string FirstName
        {
            get => selectedPerson.FirstName;
            set
            {
                selectedPerson.FirstName = value;
            }
        }
        public int Age
        {
            get => selectedPerson.Age;
            set
            {
                selectedPerson.Age = value;
            }
        }

        public Mvvm1125.MvvmCommand SavePerson { get; set; }

        private Model model;
        private readonly PageContainer pageContainer;
        private Person selectedPerson = new Person();

        public ViewModelPage2(Model model, PageContainer pageContainer)
        {
            this.model = model;
            this.pageContainer = pageContainer;
            SavePerson = new Mvvm1125.MvvmCommand(
                () => {
                    model.SavePerson(selectedPerson);
                    pageContainer.CreatePagePersonList();
                },
                ()=> true);
        }

        public ViewModelPage2(Model model, PageContainer pageContainer, Person selectedPerson) : this(model, pageContainer)
        {
            this.selectedPerson = selectedPerson;
        }
    }
}