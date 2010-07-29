using System.Collections.Generic;
using Spec.Dox.Presentation.Presenters;

namespace Spec.Dox
{
    public interface IConsole
    {
        void Execute(IEnumerable<string> command_line_arguments);
    }

    public class Console : IConsole
    {
        readonly IReportPresenter presenter;

        public Console() : this(new ReportPresenter()) {}

        public Console(IReportPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void Execute(IEnumerable<string> command_line_arguments)
        {
            presenter.Initialize(command_line_arguments);
        }
    }
}