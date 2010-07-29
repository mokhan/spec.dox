using System.Collections.Generic;
using System.Linq;
using Spec.Dox.Domain.Repositories;
using Spec.Dox.Presentation.Views;

namespace Spec.Dox.Presentation.Presenters
{
    public interface IReportPresenter
    {
        void Initialize(IEnumerable<string> command_line_arguments);
    }

    public class ReportPresenter : IReportPresenter
    {
        readonly IHtmlReport report;
        readonly ITestContextRepository repository;

        public ReportPresenter() : this(new HtmlReport(), new TestContextRepository()) {}

        public ReportPresenter(IHtmlReport report, ITestContextRepository repository)
        {
            this.report = report;
            this.repository = repository;
        }

        public void Initialize(IEnumerable<string> command_line_arguments)
        {
            foreach (var context in repository.All(command_line_arguments.ElementAt(0)))
                report.Add(context, context.AllSpecifications());
            report.publish_to_same_folder_as(command_line_arguments.ElementAt(0));
        }
    }
}