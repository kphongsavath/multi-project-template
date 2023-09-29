using System.Runtime.CompilerServices;

namespace $ext_safeprojectname$.Business.Logic.Interfaces
{
    public interface IProcessLogic
    {
        void ExecuteProcess([CallerMemberName] string callerName = "");

    }
}
