using System.Windows.Forms;

namespace DonaLaura.WinApp.Features
{
    public abstract class FormManager
    {
        public abstract void Add();

        public abstract UserControl LoadLinsting();

        public abstract string GetRegisterType();

        public abstract void Delete();

        public abstract void Update();

        public abstract void UpdateList();
    }
}
