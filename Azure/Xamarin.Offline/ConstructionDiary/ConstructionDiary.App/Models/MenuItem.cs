using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ConstructionDiary.App.Models
{
    public class MenuItem
    {
        public MenuItem(string title, ICommand command)
        {
            Title = title;
            Command = command;
        }

        public ICommand Command { get; }

        public string Title { get; }
    }
}