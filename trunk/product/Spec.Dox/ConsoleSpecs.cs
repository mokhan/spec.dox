using MbUnit.Framework;
using Spec.Dox.Presentation.Presenters;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox
{
    public class ConsoleSpecs
    {
        [Concern(typeof (Console))]
        public class when_the_console_is_given_valid_console_arguments : context_spec<IConsole>
        {
            string[] command_line_arguments;
            IReportPresenter presenter;

            protected override IConsole EstablishContext()
            {
                command_line_arguments = new[] {"path", "testfixtureattributename"};
                presenter = Dependency<IReportPresenter>();

                return new Console(presenter);
            }

            protected override void Because()
            {
                sut.Execute(command_line_arguments);
            }

            [Test]
            public void should_initialize_the_report_presenter()
            {
                presenter.received(p => p.Initialize(command_line_arguments));
            }
        }
    }
}