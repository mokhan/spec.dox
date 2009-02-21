using Spec.Dox.Presentation.Presenters;

namespace Spec.Dox {
    public interface IConsole {
        void Execute(string[] command_line_arguments);
    }

    public class Console : IConsole {
        private readonly IReportPresenter presenter;

        public Console(IReportPresenter presenter) {
            this.presenter = presenter;
        }

        public void Execute(string[] command_line_arguments) {
            presenter.Initialize();
        }
    }
}