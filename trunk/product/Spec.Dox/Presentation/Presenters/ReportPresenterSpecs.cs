using System.Collections.Generic;
using MbUnit.Framework;
using Spec.Dox.Domain;
using Spec.Dox.Domain.Repositories;
using Spec.Dox.Presentation.Presenters;
using Spec.Dox.Presentation.Views;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox.Presentation.Presenters {
    public interface ReportPresenterSpecs {}

    [Concern(typeof (ReportPresenter))]
    public class when_initializing_the_report_presenter : context_spec<IReportPresenter> {
        private ITestContextRepository repository;
        private ITestContext context;
        private IHtmlReport view;
        private IList<ITestSpecification> specifications;

        protected override IReportPresenter UnderTheseConditions() {
            repository = Dependency<ITestContextRepository>();
            view = Dependency<IHtmlReport>();
            context = Stub<ITestContext>();
            specifications = new List<ITestSpecification>();

            repository
                .setup_result_for(r => r.All())
                .Return(new List<ITestContext> {context});
            context
                .setup_result_for(c => c.AllSpecifications())
                .Return(specifications);

            return new ReportPresenter(view, repository);
        }

        protected override void BecauseOf() {
            sut.Initialize();
        }

        [Test]
        public void should_retrieving_all_the_contexts_to_display() {
            repository.should_have_been_asked_to(r => r.All());
        }

        [Test]
        public void should_retrieve_each_of_the_specification_that_belong_to_the_context() {
            context.should_have_been_asked_to(c => c.AllSpecifications());
        }

        [Test]
        public void should_display_the_specification_for_each_context() {
            view.should_have_been_asked_to(v => v.Add(context, specifications));
        }

        [Test]
        public void should_generate_the_report() {
            view.should_have_been_asked_to(v => v.PublishToFinalDestination());
        }
    }
}