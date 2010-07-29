using System.Collections.Generic;
using MbUnit.Framework;
using Spec.Dox.Domain;
using Spec.Dox.Domain.Repositories;
using Spec.Dox.Presentation.Views;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox.Presentation.Presenters
{
    public interface ReportPresenterSpecs {}

    [Concern(typeof (ReportPresenter))]
    public class when_initializing_the_report_presenter : context_spec<IReportPresenter>
    {
        ITestContextRepository repository;
        ITestContext context;
        IHtmlReport view;
        IList<ITestSpecification> specifications;
        string[] args = new[] {"1", "2"};

        protected override IReportPresenter EstablishContext()
        {
            repository = Dependency<ITestContextRepository>();
            view = Dependency<IHtmlReport>();
            context = Stub<ITestContext>();
            specifications = new List<ITestSpecification>();

            repository
                .is_told_to(r => r.All("1"))
                .Return(new List<ITestContext> {context});
            context
                .is_told_to(c => c.AllSpecifications())
                .Return(specifications);

            return new ReportPresenter(view, repository);
        }

        protected override void Because()
        {
            sut.Initialize(args);
        }

        [Test]
        public void should_retrieve_each_of_the_specification_that_belong_to_the_context()
        {
            context.received(c => c.AllSpecifications());
        }

        [Test]
        public void should_display_the_specification_for_each_context()
        {
            view.received(v => v.Add(context, specifications));
        }

        [Test]
        public void should_generate_the_report()
        {
            view.received(v => v.publish_to_same_folder_as("1"));
        }
    }
}