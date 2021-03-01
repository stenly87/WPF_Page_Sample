using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp28
{
    public class PageContainer
    {
        Model model;
        private Page currentPage1;

        Page currentPage
        {
            get => currentPage1;
            set { currentPage1 = value;
                CurrentPageChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<Page> CurrentPageChanged;

        Stack<Page> history = new Stack<Page>();
        Stack<Page> backHistory = new Stack<Page>();

        public PageContainer(Model model)
        {
            this.model = model;
        }

        Page1 personList;
        internal void CreatePagePersonList()
        {
            if (personList == null)
                personList = new Page1(new ViewModelPage1(model, this));
            currentPage = personList;
        }

        internal void CreatePagePersonEdit()
        {
            if (currentPage != null)
                history.Push(currentPage);
            currentPage = new Page2(new ViewModelPage2(model, this));
        }

        internal void CreatePagePersonEdit(Person selectedPerson)
        {
            if (currentPage != null)
                history.Push(currentPage);
            currentPage = new Page2(new ViewModelPage2(model, this, selectedPerson));
        }

        internal bool BackPageExist()
        {
            return history.Count > 0;
        }

        internal void Back()
        {
            if (!BackPageExist())
                return;

            backHistory.Push(currentPage);
            currentPage = history.Pop();            
        }

        internal void Forward()
        {
            if (!ForwardPageExist())
                return;

            history.Push(currentPage);
            currentPage = backHistory.Pop();
        }

        internal bool ForwardPageExist()
        {
            return backHistory.Count > 0;
        }
    }
}