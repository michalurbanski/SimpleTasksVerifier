using SimpleTasksVerifier.Models;
using System.Collections.Generic;

namespace SimpleTasksVerifier.Interfaces
{
    public interface IFileProcessor
    {
        IEnumerable<TaskResult> ProcessFile();
    }
}
