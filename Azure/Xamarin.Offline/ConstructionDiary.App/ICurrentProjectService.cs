using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDiary.Model;

namespace ConstructionDiary.App
{
    public interface ICurrentProjectService
    {
        ProjectInfo Current { get; }

        void Change(ProjectInfo project);

        IDisposable Register(Action<ProjectInfo> register);
    }
}