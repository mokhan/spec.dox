using System;
using System.IO;

namespace Spec.Dox.Presentation.Views {
    public interface IReportPublisher {
        void Publish(string expected_html);
    }

    public class ReportPublisher : IReportPublisher {
        public void Publish(string html_to_publish) {
            var pathToWriteReportTo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "report.html");
            File.WriteAllText(pathToWriteReportTo, html_to_publish);
            System.Console.Out.WriteLine("Report published to... {0}", pathToWriteReportTo);
        }
    }
}