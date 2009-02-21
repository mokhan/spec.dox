using Spec.Dox.Domain.Repositories;
using Spec.Dox.Presentation.Views;

namespace Spec.Dox.Presentation.Presenters {
    public interface IReportPresenter {
        void Initialize();
    }

    public class ReportPresenter : IReportPresenter {
        private readonly IHtmlReport report;
        private readonly ITestContextRepository repository;

        public ReportPresenter(IHtmlReport report, ITestContextRepository repository) {
            this.report = report;
            this.repository = repository;
        }

        public void Initialize() {
            foreach (var context in repository.All()) {
                report.Add(context, context.AllSpecifications());
            }
            report.PublishToFinalDestination();
        }
    }
}