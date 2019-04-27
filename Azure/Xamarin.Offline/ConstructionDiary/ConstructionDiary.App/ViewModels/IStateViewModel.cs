﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ConstructionDiary.App.ViewModels
{
    public interface IStateViewModel
    {
        string CurrentState { get; }

        string Label { get; }

        ICommand SwitchCommand { get; }
    }
}