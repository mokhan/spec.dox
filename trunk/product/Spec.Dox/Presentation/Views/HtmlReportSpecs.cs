using System.Collections.Generic;
using MbUnit.Framework;
using Rhino.Mocks;
using Spec.Dox.Domain;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox.Presentation.Views {
    public class HtmlReportSpecs {}

    [Concern(typeof (HtmlReport))]
    public class when_publishing_an_html_report_with_specification_added_to_it : context_spec<IHtmlReport> {
        private IReportPublisher publisher;

        protected override IHtmlReport UnderTheseConditions() {
            publisher = Dependency<IReportPublisher>();

            var fixture = Stub<ITestContext>();
            var testSpecification = Stub<ITestSpecification>();


            fixture.setup_result_for(f => f.Name).Return("when_a_blah_blah");
            testSpecification.setup_result_for(t => t.Name).Return("should_do_some_stuff");

            var context = new HtmlReport(publisher);
            context.Add(fixture, new List<ITestSpecification> {testSpecification});
            return context;
        }

        protected override void BecauseOf() {
            sut.PublishToFinalDestination();
        }

        [Test]
        public void should_publish_the_correct_html() {
            var expected_html =
                "<html><head><title>Specifications Document</title></head><body><h1>when a blah blah</h1><ul><li>should do some stuff</li></ul></body></html>";

            publisher.should_have_been_asked_to(p => p.Publish(Arg<string>.Is.Equal(expected_html)));
        }
    }
}