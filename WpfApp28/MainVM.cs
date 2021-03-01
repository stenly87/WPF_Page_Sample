using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp28
{
    public class MainVM : Mvvm1125.MvvmNotify
    {
        Model model;
        PageContainer pageContainer;
        private Page currentPage;
        private string pageCaption;

        public string PageCaption
        {
            get => pageCaption;
            set { pageCaption = value; NotifyPropertyChanged(); }
        }
        public Page CurrentPage
        {
            get => currentPage;
            set { currentPage = value; NotifyPropertyChanged(); }
        }

        public Mvvm1125.MvvmCommand BackPage { get; set; }
        public Mvvm1125.MvvmCommand ForwardPage { get; set; }

        public MainVM()
        {
            model = new Model();
            pageContainer = new PageContainer(model);
            pageContainer.CurrentPageChanged += Page1_PageChange;
            pageContainer.CreatePagePersonList();
            BackPage = new Mvvm1125.MvvmCommand(
                () => pageContainer.Back(),
                () => pageContainer.BackPageExist());
            ForwardPage = new Mvvm1125.MvvmCommand(
                () => pageContainer.Forward(),
                ()=> pageContainer.ForwardPageExist());
        }

        private void Page1_PageChange(object sender, Page e)
        {
            PageCaption = e.Title;
            CurrentPage = e;
        }
    }
}
