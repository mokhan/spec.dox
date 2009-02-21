using System.Collections.Generic;
using System.Text;
using Spec.Dox.Domain;

namespace Spec.Dox.Presentation.Views {
    public interface IHtmlReport {
        void Add(ITestContext context, IEnumerable<ITestSpecification> specifications);
        void PublishToFinalDestination();
    }

    public class HtmlReport : IHtmlReport {
        private readonly IReportPublisher publisher;
        private readonly StringBuilder builder;

        public HtmlReport(IReportPublisher publisher) {
            this.publisher = publisher;
            builder = new StringBuilder();
            builder.Append("<html><head><title>Specifications Document</title></head><body>");
        }

        public void Add(ITestContext context, IEnumerable<ITestSpecification> specifications) {
            builder.AppendFormat("<h1>{0}</h1>", context.Name.Replace("_", " "));
            builder.Append("<ul>");
            foreach (var specification in specifications) {
                builder.AppendFormat("<li>{0}</li>", specification.Name.Replace("_", " "));
            }
            builder.Append("</ul>");
        }

        public void PublishToFinalDestination() {
            builder.Append("</body></html>");
            publisher.Publish(builder.ToString());
        }
    }
}